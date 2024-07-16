using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Domain.Models.DTOs;

public class UserDto(UserEntity userEntity)
{
    public int Id { get; init; } = userEntity.Id;
    public string? FirstName { get; set; } = userEntity.FirstName;
    public string? LastName { get; set; } = userEntity.LastName;
    public string? Email { get; set; } = userEntity.Email;
    public string? Username { get; set; } = userEntity.Username;
}