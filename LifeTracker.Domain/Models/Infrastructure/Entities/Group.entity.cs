namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class GroupEntity
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    public List<UserEntity>? Users { get; set; }
}