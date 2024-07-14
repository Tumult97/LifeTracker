using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Users;

public interface IUserQueryManager
{
    List<UserEntity> GetUserList(Expression<Func<UserEntity, bool>>? predicate = null, bool includeTracking = false);
    UserEntity? GetUserSingle(Expression<Func<UserEntity, bool>>? predicate = null, bool includeTracking = false);
}