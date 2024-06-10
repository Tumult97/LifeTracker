using dotnet_helpers.Models;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;

namespace LifeTracker.Application.Services.Entities.GroupService.Interfaces;

public interface IGroupCommandService
{
    ServiceResult<GroupDto> CreateGroup(GroupCreationRequest groupCreationRequest);
}