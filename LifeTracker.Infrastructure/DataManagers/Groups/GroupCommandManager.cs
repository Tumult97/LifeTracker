using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;

namespace LifeTracker.Infrastructure.DataManagers.Groups;

public class GroupCommandManager(DatabaseContext context) : IGroupCommandManager
{
    public void Create(GroupEntity group)
    {
        context.Groups.Add(group);
    }

    public void Update(GroupEntity group)
    {
        context.Groups.Update(group);
    }

    public void AddUserMappings(List<UserGroupEntity> userGroups)
    {
        context.UserGroups.AddRange(userGroups);
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}