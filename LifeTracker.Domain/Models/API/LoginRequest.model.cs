namespace LifeTracker.Domain.Models.API;

public class LoginRequestModel
{
    public string Password { get; set; }
    public string EmailOrUsername { get; set; }
}