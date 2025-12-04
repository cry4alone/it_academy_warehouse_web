using System.Security.Cryptography;
using Storage.BLL.Services.Interfaces;

namespace Storage.BLL.Services;

public class PasswordHashingService : IPasswordHashingService
{
    private const int saltSize = 128 / 8;
    private const int hashSize = 256 / 8;
    private const int iterations = 1000;
        
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;
    
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, Algorithm, hashSize);
        
        return Convert.ToBase64String(hash) + "-" + Convert.ToBase64String(salt);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split('-');
        
        var hash = Convert.FromBase64String(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        
        Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, iterations, Algorithm, hashSize);
        
        return CryptographicOperations.FixedTimeEquals(hash, salt);
    }
}