using dotnet_helpers.Models;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;

namespace LifeTracker.Application.Services.Entities.GroupService;

public interface IGroupCommandService
{
    Task<ServiceResult<GroupDto>> CreateGroup(GroupCreationRequest groupCreationRequest);
}