using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;

namespace LifeTracker.Infrastructure.Command_Managers.Groups;

public class GroupCommandManager(DatabaseContext context) : IGroupCommandManager
{
    public void Create(GroupEntity group)
    {
        context.groups.Add(group);
    }

    public void Update(GroupEntity group)
    {
        context.groups.Update(group);
    }

    public void AddUserMappings(List<UserGroupEntity> userGroups)
    {
        context.userGroups.AddRange(userGroups);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}