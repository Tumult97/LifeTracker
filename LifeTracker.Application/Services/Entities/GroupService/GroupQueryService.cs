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
    private readonly string? _loggedInUserId;

    public GroupQueryService(
        IHttpContextAccessor httpContextAccessor,
        IUserQueryManager userQueryManager)
    {
        _userQueryManager = userQueryManager;
        _loggedInUserId = httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value ?? null;
    }

    public ServiceResult<IReadOnlyList<GroupDto>> GetGroupsForCurrentUser()
    {
        var user = _userQueryManager.GetUserSingle(includeGroups: true, predicate: user => user.Email == _loggedInUserId);

        if (user == null)
        {
            return ServiceResult<IReadOnlyList<GroupDto>>.MakeFailure("User not found.");
        }

        if (user.Groups == null || user.Groups.Count == 0)
        {
            return ServiceResult<IReadOnlyList<GroupDto>>.MakeFailure("User has no groups.");
        }

        var userGroups = user.Groups;

        IReadOnlyList<GroupDto> response = userGroups.Select(group => new GroupDto(group, true)).ToList();
        
        return ServiceResult<IReadOnlyList<GroupDto>>.MakeSuccess(response);
    }
}