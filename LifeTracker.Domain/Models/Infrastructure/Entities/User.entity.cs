namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class UserEntity(string firstName, string lastName, string email, string username, string passwordHash, string passwordSalt)
{
    public int Id { get; init; }
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public string Username { get; set; } = username;
    public string PasswordHash { get; set; } = passwordHash;
    public string PasswordSalt { get; set; } = passwordSalt;
    
    public List<GroupEntity>? Groups { get; set; }
    public List<ExpenseEntity>? Expenses { get; set; }
}