namespace LifeTracker.Domain.Models.API;

public class LoginRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime DateOfJoing { get; set; }
}