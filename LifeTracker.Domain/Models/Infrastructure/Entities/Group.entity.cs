using LifeTracker.Domain.Models.API;

namespace LifeTracker.Domain.Models.Infrastructure.Entities;

public class GroupEntity(): AuditModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public List<UserEntity>? Users { get; set; }
    
    public GroupEntity(GroupCreationRequest groupCreationRequest) : this()
    {
        Id = 0;
        Name = groupCreationRequest.Name ?? "";
        Description = groupCreationRequest.Description ?? "";
        Address = groupCreationRequest.Address ?? "";
        Users = new List<UserEntity>();
    }
}