using dotnet_helpers.Models;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;

namespace LifeTracker.Application.Services.Entities.GroupService.Interfaces;

public interface IGroupQueryService
{
    ServiceResult<IReadOnlyList<GroupDto>> GetGroupsForCurrentUser();
}