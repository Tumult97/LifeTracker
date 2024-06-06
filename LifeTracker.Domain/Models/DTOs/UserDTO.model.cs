using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.DTOs;

public class UserDtoModel()
{
    public int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    
    public UserDtoModel(UserEntity userEntity) : this()
    {
        Id = userEntity.Id;
        FirstName = userEntity.FirstName;
        LastName = userEntity.LastName;
        Email = userEntity.Email;
        Username = userEntity.Username;
    }
    
    public UserDtoModel(LoginRequestModel loginRequestModel) : this()
    {
        FirstName = "";
        LastName = "";
        Email = loginRequestModel.Email;
        Username = loginRequestModel.Username;
    }
}