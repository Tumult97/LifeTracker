namespace LifeTracker.Application.Services.Security.PasswordService;

public interface IPasswordService
{
    string ComputeHash(string password, string salt, string pepper, int iteration);
    string GenerateSalt();
}