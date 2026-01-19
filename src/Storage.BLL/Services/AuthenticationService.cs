using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Storage.BLL.Common.Services.Interfaces;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests.AuthenticationRequests;
using Storage.BLL.Exceptions;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Storage.BLL.Services;

/// <inheritdoc cref="IAuthenticationService" />
public class AuthenticationService : IAuthenticationService
{
    private readonly IPasswordHashingService _passwordHashingService;
    
    /// <inheritdoc cref="IUserRepository"/>>
    private readonly IUserRepository _userRepository;
    
    private readonly IConfiguration _configuration;
    
    /// <inheritdoc cref="IRefreshTokenRepository"/>>
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    
    /// <inheritdoc cref="ICurrentUserService"/>>
    private readonly ICurrentUserService _currentUserService;
    
    /// <inheritdoc cref="IDateTimeProvider"/>>
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(IPasswordHashingService passwordHashingService,
        IUserRepository userRepository,
        IConfiguration configuration,
        IRefreshTokenRepository refreshTokenRepository,
        ICurrentUserService currentUserService,
        IDateTimeProvider dateTimeProvider)
    {
        _passwordHashingService = passwordHashingService;
        _userRepository = userRepository;
        _configuration = configuration;
        _refreshTokenRepository = refreshTokenRepository;
        _currentUserService = currentUserService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return null;
        
        var user = await _userRepository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user == null) throw new NotFoundException(nameof(user));

        var passwordMatches = _passwordHashingService.VerifyHashedPassword(user.PasswordHash, request.Password);
        if (!passwordMatches) throw new InvalidCredentialsException();

        var accessToken = await GenerateJwtToken(user.UserId, user.Username, user.FirstName, user.Surname, cancellationToken);
        
        var refreshToken = GenerateRefreshToken();
        await _refreshTokenRepository.RemoveAllAsync(user.UserId, cancellationToken);
        
        var newRefreshToken = new RefreshToken()
        {
            Token = refreshToken,
            ExpiresAt = _dateTimeProvider.UtcMonthFromNow(1),
            UserId = user.UserId,
            User = user
        };
        
        await _refreshTokenRepository.AddAsync(newRefreshToken, cancellationToken);

        return new AuthenticationResponse(
            user.UserId,
            user.Username,
            user.FirstName,
            user.Surname,
            accessToken,
            refreshToken);
    }

    public async Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default)
    {
        var checkedRefreshToken = await _refreshTokenRepository.GetAsync(refreshToken.Token, cancellationToken);
        if (checkedRefreshToken is null) throw new InvalidRefreshTokenException();
        
        if (checkedRefreshToken.ExpiresAt <= _dateTimeProvider.UtcNow) {
            await _refreshTokenRepository.RemoveAsync(checkedRefreshToken,  cancellationToken);
            throw new InvalidRefreshTokenException();
        }
        
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        if (currentUser is null) throw new NotFoundException(nameof(currentUser));
        
        var newRefreshToken = GenerateRefreshToken();
        
        checkedRefreshToken.ExpiresAt = _dateTimeProvider.UtcMonthFromNow(1);
        checkedRefreshToken.Token = newRefreshToken;
        await _refreshTokenRepository.UpdateAsync(checkedRefreshToken, cancellationToken);
        
        var accessToken = await GenerateJwtToken(currentUser.UserId, currentUser.Username, currentUser.FirstName,
            currentUser.Surname, cancellationToken);
        
        
        return new AuthenticationResponse(
            currentUser.UserId,
            currentUser.Username,
            currentUser.FirstName,
            currentUser.Surname,
            accessToken,
            newRefreshToken);
    }

    public async Task Logout(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default)
    {
        var existingRefreshToken = await _refreshTokenRepository.GetAsync(refreshToken.Token, cancellationToken);
        if (existingRefreshToken is null) return;
        
        await _refreshTokenRepository.RemoveAsync(existingRefreshToken, cancellationToken);
    }
    
    private async Task<string> GenerateJwtToken(int userId,
        string username,
        string firstName,
        string surname,
        CancellationToken cancellationToken = default)
    {
        var secret = _configuration["Jwt:Secret"];
        if (string.IsNullOrWhiteSpace(secret))
            throw new InvalidOperationException("JWT secret is not configured.");

        var signingCredentials =
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.FamilyName, surname),
            new Claim(JwtRegisteredClaimNames.Name, firstName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        var userPermissions = await _userRepository.GetUserRolesAsync(userId, cancellationToken);
        var permissionClaims = new List<Claim>();
        foreach (var permission in userPermissions)
        {
           permissionClaims.Add(new Claim("permission", permission));
        }
        var allClaims = claims.Concat(permissionClaims);

        var expiryText = _configuration["JwtSettings:ExpiryMinutes"];
        if (!int.TryParse(expiryText, out var expiration)) expiration = 30;

        var token = new JwtSecurityToken(
            audience: _configuration["JwtSettings:Audience"],
            issuer: _configuration["JwtSettings:Issuer"],
            claims: allClaims,
            expires: _dateTimeProvider.UtcMinutesFromNow(expiration),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}