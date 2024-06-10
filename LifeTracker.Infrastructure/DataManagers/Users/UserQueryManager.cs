using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LifeTracker.Infrastructure.DataManagers.Users;

public class UserQueryManager(DatabaseContext context) : IUserQueryManager
{
    public List<UserEntity> GetUserList(
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
            return userContext.Where(predicate).ToList();
        }

        return userContext.ToList();
    }
    
    public UserEntity? GetUserSingle(
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
            return userContext.FirstOrDefault(predicate);
        }

        return userContext.FirstOrDefault();
    }
}