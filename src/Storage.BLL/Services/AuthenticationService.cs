using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Storage.BLL.Common;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.DTO.Requests.AuthenticationRequests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Storage.BLL.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ICurrentUserService _currentUserService;
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
        if (user == null) return null;

        var passwordMatches = _passwordHashingService.VerifyHashedPassword(user.PasswordHash, request.Password);
        if (!passwordMatches) return null;

        var accessToken = await GenerateJwtToken(user.UserId, user.Username, user.FirstName, user.Surname, cancellationToken);
        
        var refreshToken = GenerateRefreshToken();
        await _refreshTokenRepository.RemoveAllAsync(cancellationToken);
        
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
        if (checkedRefreshToken is null || checkedRefreshToken.ExpiresAt <= _dateTimeProvider.UtcNow) {
            await _refreshTokenRepository.RemoveAsync(checkedRefreshToken,  cancellationToken);
            return null; //user should authenticate again
        }
        
        var currentUser = await _currentUserService.GetCurrentUserAsync();
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
        foreach (var permission in userPermissions)
        {
            claims = claims.Append(new Claim("permission", permission)).ToArray();
        }

        var expiryText = _configuration["JwtSettings:ExpiryMinutes"];
        if (!double.TryParse(expiryText, out var expiration)) expiration = 60;

        var token = new JwtSecurityToken(
            audience: _configuration["JwtSettings:Audience"],
            issuer: _configuration["JwtSettings:Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiration),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}