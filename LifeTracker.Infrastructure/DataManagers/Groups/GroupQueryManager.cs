using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Groups;

public class GroupQueryManager(DatabaseContext context) : IGroupQueryManager
{
    public async Task<List<GroupEntity>> GetGroupListAsync(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false)
    {
        var groupContext = (includeTracking ? context.Groups : context.Groups.AsNoTracking()).IgnoreAutoIncludes();
        
        groupContext = includeUsers ? groupContext.Include(x => x.Users) : groupContext;
        
        if (predicate != null)
        {
            return await groupContext.Where(predicate).ToListAsync();
        }
        
        return await groupContext.ToListAsync();
    }

    public async Task<GroupEntity?> GetGroupSingleAsync(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false)
    {
        var groupContext = (includeTracking ? context.Groups : context.Groups.AsNoTracking()).IgnoreAutoIncludes();
        
        groupContext = includeUsers ? groupContext.Include(x => x.Users) : groupContext;
        
        if (predicate != null)
        {
            return await groupContext.FirstOrDefaultAsync(predicate);
        }
        
        return await groupContext.FirstOrDefaultAsync();
    }
}