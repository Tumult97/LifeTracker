using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LifeTracker.Application.Services.Security.PasswordService;

public class PasswordService(IConfiguration configuration) : IPasswordService
{
    private readonly string _pepper = configuration["PasswordPepper"]!;
    
    /// <summary>
    /// Generates a hashed string from a given password, salt, and a specified number of iterations using SHA-256.
    /// </summary>
    /// <param name="password">The plain-text password to be hashed.</param>
    /// <param name="salt">A salt value to add randomness to the password hash, enhancing security.</param>
    /// <param name="iteration">The number of times the hashing operation is performed. Must be a positive integer.</param>
    /// <returns>The resulting hash value after the specified number of iterations.</returns>
    public string ComputeHash(string password, string salt, int iteration)
    {
        // If the iteration count is less than or equal to 0, return the input password as is
        if (iteration <= 0) return password;
    
        // Create an instance of the SHA-256 cryptographic hash algorithm
        using var sha256 = SHA256.Create();
    
        // Concatenate the password, salt, and a pepper value (stored in _pepper)
        var passwordSaltPepper = $"{password}{salt}{_pepper}";
    
        // Convert the concatenated string to a byte array using UTF-8 encoding
        var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
    
        // Compute the SHA-256 hash of the byte array
        var byteHash = sha256.ComputeHash(byteValue);
    
        // Convert the byte array hash to a Base64-encoded string
        var hash = Convert.ToBase64String(byteHash);
    
        // Recursively call ComputeHash with the new hash, same salt, and decremented iteration count
        return ComputeHash(hash, salt, iteration - 1);
    }

    /// <summary>
    /// Generates a cryptographically secure salt using a random number generator.
    /// </summary>
    /// <returns>A Base64-encoded string representing the generated salt.</returns>
    public string GenerateSalt()
    {
        // Create an instance of a cryptographically secure random number generator
        using var rng = RandomNumberGenerator.Create();
    
        // Create a byte array to hold the random bytes (16 bytes for a 128-bit salt)
        var byteSalt = new byte[16];
    
        // Fill the byte array with cryptographically strong random bytes
        rng.GetBytes(byteSalt);
    
        // Convert the byte array to a Base64-encoded string
        var salt = Convert.ToBase64String(byteSalt);
    
        // Return the generated salt
        return salt;
    }

    public bool VerifyPassword(string password, string passwordHash, string passwordSalt)
    {
        var requestPasswordHash = ComputeHash(password, passwordSalt, 3);
        
        return requestPasswordHash == passwordHash;
    }
}