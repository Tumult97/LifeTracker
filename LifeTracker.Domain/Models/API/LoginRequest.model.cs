namespace LifeTracker.Domain.Models.API;

public class LoginRequestModel
{
    public string Password { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}