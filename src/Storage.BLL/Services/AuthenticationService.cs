using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Repositories;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Storage.BLL.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly UserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationService(IPasswordHashingService passwordHashingService, UserRepository userRepository, IConfiguration configuration)
    {
        _passwordHashingService = passwordHashingService;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponse?> Authenticate(LoginRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return null;
        
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null) return null;

        var passwordMatches = _passwordHashingService.VerifyHashedPassword(user.PasswordHash, request.Password);
        if (!passwordMatches) return null;

        var token = GenerateJwtToken(user.UserId, user.Username, user.FirstName, user.Surname);

        return new LoginResponse(
            user.UserId,
            user.Username,
            user.FirstName,
            user.Surname,
            token);
    }

    private string GenerateJwtToken(int userId, string username, string firstName, string surname)
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
            // add role somewhere here
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

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
}