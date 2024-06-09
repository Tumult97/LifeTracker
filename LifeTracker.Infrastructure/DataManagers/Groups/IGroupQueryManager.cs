using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Groups;

public interface IGroupQueryManager
{
    Task<List<GroupEntity>> GetGroupListAsync(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false);
    Task<GroupEntity?> GetGroupSingleAsync(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false);
}