using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.DTOs;

public class GroupDto()
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public List<UserDto>? Users { get; set; }
    
    public GroupDto(GroupEntity groupEntity, bool populateUsers = false) : this()
    {
        Id = groupEntity.Id;
        Name = groupEntity.Name;
        Description = groupEntity.Description;
        Address = groupEntity.Address;
        Users = populateUsers ? groupEntity.Users?.Select(user => new UserDto(user)).ToList() ?? null : null;
    }
}