using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Users;

public class UserQueryManager(DatabaseContext context) : IUserQueryManager
{
    public async Task<List<UserEntity>> GetUserListAsync(
        Expression<Func<UserEntity, bool>>? predicate = null,
        bool includeTracking = false, 
        bool includeGroups = false,
        bool includeExpenses = false)
    {
        var userContext = (includeTracking ? context.Users : context.Users.AsNoTracking()).IgnoreAutoIncludes();
        
        userContext = includeGroups ? userContext.Include(x => x.Groups) : userContext;

        userContext = includeExpenses ? userContext.Include(x => x.Expenses) : userContext;

        if (predicate != null)
        {
            return await userContext.Where(predicate).ToListAsync();
        }

        return await userContext.ToListAsync();
    }
    
    public async Task<UserEntity?> GetUserSingleAsync(
        Expression<Func<UserEntity, bool>>? predicate = null,
        bool includeTracking = false, 
        bool includeGroups = false,
        bool includeExpenses = false)
    {
        var userContext = (includeTracking ? context.Users : context.Users.AsNoTracking()).IgnoreAutoIncludes();
        
        userContext = includeGroups ? userContext.Include(x => x.Groups) : userContext;

        userContext = includeExpenses ? userContext.Include(x => x.Expenses) : userContext;

        if (predicate != null)
        {
            return await userContext.FirstOrDefaultAsync(predicate);
        }

        return await userContext.FirstOrDefaultAsync();
    }
}