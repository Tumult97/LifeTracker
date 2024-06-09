using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.QueryManagers.Users;

public interface IUserQueryManager
{
    Task<List<UserEntity>> GetUserListAsync(Expression<Func<UserEntity, bool>>? predicate = null, bool includeTracking = false, bool includeData = false);
    Task<UserEntity?> GetUserSingleAsync(Expression<Func<UserEntity, bool>>? predicate = null, bool includeTracking = false, bool includeData = false);
}