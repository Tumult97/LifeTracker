using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.DTOs;

public class UserDto()
{
    public int Id { get; init; }
    public string? FirstName { get; set; } = null;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public List<GroupDto>? Groups { get; set; }
    
    public UserDto(UserEntity userEntity, List<GroupEntity>? groups = null) : this()
    {
        Id = userEntity.Id;
        FirstName = userEntity.FirstName;
        LastName = userEntity.LastName;
        Email = userEntity.Email;
        Username = userEntity.Username;
        Groups = groups?.Select(group => new GroupDto(group)).ToList();
    }
}