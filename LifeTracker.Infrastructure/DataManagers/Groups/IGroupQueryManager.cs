using System.Linq.Expressions;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Infrastructure.DataManagers.Groups;

public interface IGroupQueryManager
{
    List<GroupEntity> GetGroupList(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false);
    GroupEntity? GetGroupSingle(Expression<Func<GroupEntity, bool>>? predicate = null, bool includeTracking = false, bool includeUsers = false);
}