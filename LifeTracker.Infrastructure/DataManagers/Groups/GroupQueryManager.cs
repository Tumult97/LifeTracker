using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Groups;

public class GroupQueryManager(DatabaseContext context) : IGroupQueryManager
{
    public List<GroupEntity> GetGroupList(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false)
    {
        var groupContext = (includeTracking ? context.Groups : context.Groups.AsNoTracking()).IgnoreAutoIncludes();
        
        groupContext = includeUsers ? groupContext.Include(x => x.Users) : groupContext;
        
        if (predicate != null)
        {
            return groupContext.Where(predicate).ToList();
        }
        
        return groupContext.ToList();
    }

    public GroupEntity? GetGroupSingle(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false)
    {
        var groupContext = (includeTracking ? context.Groups : context.Groups.AsNoTracking()).IgnoreAutoIncludes();
        
        groupContext = includeUsers ? groupContext.Include(x => x.Users) : groupContext;
        
        if (predicate != null)
        {
            return groupContext.FirstOrDefault(predicate);
        }
        
        return groupContext.FirstOrDefault();
    }
}