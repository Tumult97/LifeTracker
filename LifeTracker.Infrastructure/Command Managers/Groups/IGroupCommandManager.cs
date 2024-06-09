using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.Command_Managers.Groups;

public interface IGroupCommandManager
{
    void Create(GroupEntity group);
    
    void Update(GroupEntity group);

    void AddUserMappings(List<UserGroupEntity> userGroups);

    void SaveChanges();
}