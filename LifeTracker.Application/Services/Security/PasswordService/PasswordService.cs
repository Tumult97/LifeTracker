using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LifeTracker.Application.Services.Security.PasswordService;

public class PasswordService(IConfiguration configuration) : IPasswordService
{
    private readonly string _pepper = configuration["PasswordPepper"]!;
    
    public string ComputeHash(string password, string salt, int iteration)
    {
        if (iteration <= 0) return password;
        
        using var sha256 = SHA256.Create();
        var passwordSaltPepper = $"{password}{salt}{_pepper}";
        var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
        var byteHash = sha256.ComputeHash(byteValue);
        var hash = Convert.ToBase64String(byteHash);
        return ComputeHash(hash, salt, iteration - 1);
    }

    public string GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        var byteSalt = new byte[16];
        rng.GetBytes(byteSalt);
        var salt = Convert.ToBase64String(byteSalt);
        return salt;
    }

    public bool VerifyPassword(string password, string passwordHash, string passwordSalt)
    {
        var requestPasswordHash = ComputeHash(password, passwordSalt, 3);
        
        return requestPasswordHash == passwordHash;
    }
}