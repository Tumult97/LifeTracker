namespace LifeTracker.Domain.Models.Infrastructure;

public class UserModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime DateOfJoing { get; set; }
}