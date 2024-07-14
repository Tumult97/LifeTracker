using System.Linq.Expressions;
using System.Security.Claims;
using dotnet_helpers.Models;
using LifeTracker.Application.Services.Entities.GroupService.Interfaces;
using LifeTracker.Domain.Models.DTOs;
using LifeTracker.Domain.Models.Infrastructure.Entities;
using LifeTracker.Infrastructure.DataManagers.Groups;
using LifeTracker.Infrastructure.DataManagers.Users;
using Microsoft.AspNetCore.Http;

namespace LifeTracker.Application.Services.Entities.GroupService;

public class GroupQueryService : IGroupQueryService
{
    private readonly IUserQueryManager _userQueryManager;
    private readonly IGroupQueryManager _groupQueryManager;
    private readonly string? _loggedInUserId;

    public GroupQueryService(
        IHttpContextAccessor httpContextAccessor,
        IUserQueryManager userQueryManager,
        IGroupQueryManager groupQueryManager)
    {
        _userQueryManager = userQueryManager;
        _groupQueryManager = groupQueryManager;
        _loggedInUserId = httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value ?? null;
    }

    public ServiceResult<IReadOnlyList<GroupDto>> GetGroupsForCurrentUser()
    {
        var loggedInUser = _userQueryManager.GetUserSingle(predicate: user => user.Email == _loggedInUserId);

        if (loggedInUser == null)
        {
            return ServiceResult<IReadOnlyList<GroupDto>>.MakeFailure("User not found.");
        }

        var userGroups = _groupQueryManager.GetGroupList(includeUsers: true, predicate: (group) => group.Users != null && group.Users.Any(user => user.Id == loggedInUser.Id));
        
        if (userGroups.Count == 0)
        {
            return ServiceResult<IReadOnlyList<GroupDto>>.MakeFailure("User has no groups.");
        }

        IReadOnlyList<GroupDto> response = userGroups.Select(group => new GroupDto(group, true)).ToList();
        
        return ServiceResult<IReadOnlyList<GroupDto>>.MakeSuccess(response);
    }
}