using dotnet_helpers.Models;
using LifeTracker.Domain.Models.API;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.Command_Managers.Groups;
using LifeTracker.Infrastructure.QueryManagers.Users;

namespace LifeTracker.Application.Services.Entities.GroupService;

public class GroupCommandService(IGroupCommandManager groupCommandManager, IUserQueryManager userQueryManager) : IGroupCommandService
{
    public async Task<ServiceResult<GroupDto>> CreateGroup(GroupCreationRequest groupCreationRequest)
    {
        var group = new GroupEntity(groupCreationRequest);
        
        groupCommandManager.Create(group);
        
        if (groupCreationRequest.UserIds != null)
        {
            IReadOnlyList<UserEntity> users = await userQueryManager.GetUserListAsync(
                includeTracking: true, 
                predicate: user => groupCreationRequest.UserIds.Contains(user.Id));

            group.Users = users.ToList();
        }
        
        groupCommandManager.SaveChanges();
        
        return ServiceResult<GroupDto>.MakeSuccess(new GroupDto(group, true));
    }
}