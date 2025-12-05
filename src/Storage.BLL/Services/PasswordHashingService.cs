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
        if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(providedPassword)) return false;

        var parts = hashedPassword.Split('-');
        if (parts.Length != 2) return false;

        byte[] storedHash;
        byte[] salt;
        try
        {
            storedHash = Convert.FromBase64String(parts[0]);
            salt = Convert.FromBase64String(parts[1]);
        }
        catch
        {
            return false;
        }

        var derivedHash = Rfc2898DeriveBytes.Pbkdf2(providedPassword, salt, iterations, Algorithm, hashSize);

        return CryptographicOperations.FixedTimeEquals(storedHash, derivedHash);
    }
}