using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.GroupService.Interfaces;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.DataManagers.Groups;
using LifeTracker.Infrastructure.DataManagers.Users;

namespace LifeTracker.Application.Services.Entities.GroupService;

public class GroupCommandService(IGroupCommandManager groupCommandManager, IUserQueryManager userQueryManager) : IGroupCommandService
{
    public ServiceResult<GroupDto> CreateGroup(GroupCreationRequest groupCreationRequest)
    {
        var group = new GroupEntity(groupCreationRequest);
        
        groupCommandManager.Create(group);
        
        if (groupCreationRequest.UserIds != null)
        {
            IReadOnlyList<UserEntity> users = userQueryManager.GetUserList(predicate: user => groupCreationRequest.UserIds.Contains(user.Id), includeTracking: true);

            group.Users = users.ToList();
        }
        
        groupCommandManager.SaveChanges();
        
        return ServiceResult<GroupDto>.MakeSuccess(new GroupDto(group, true));
    }
}