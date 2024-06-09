using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.QueryManagers.Users;

public class UserQueryManager(DatabaseContext context) : IUserQueryManager
{
    public async Task<List<UserEntity>> GetUserListAsync(
        Expression<Func<UserEntity, bool>>? predicate = null,
        bool includeTracking = false, 
        bool includeData = false)
    {
        var userContext = includeTracking ? context.users : context.users.AsNoTracking();
        
        if (includeData)
        {
            userContext = userContext.IgnoreAutoIncludes();
        }

        if (predicate != null)
        {
            return await userContext.Where(predicate).ToListAsync();
        }

        return await userContext.ToListAsync();
    }
    
    public async Task<UserEntity?> GetUserSingleAsync(
        Expression<Func<UserEntity, bool>>? predicate = null,
        bool includeTracking = false, 
        bool includeData = false)
    {
        var userContext = includeTracking ? context.users : context.users.AsNoTracking();
        
        if (includeData)
        {
            userContext = userContext.IgnoreAutoIncludes();
        }

        if (predicate != null)
        {
            return await userContext.FirstOrDefaultAsync(predicate);
        }

        return await userContext.FirstOrDefaultAsync();
    }
}