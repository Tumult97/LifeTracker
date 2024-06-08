namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class UserGroupEntity
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int GroupId { get; init; }
    
    public UserEntity? User { get; init; }
    public GroupEntity? Group { get; init; }
}