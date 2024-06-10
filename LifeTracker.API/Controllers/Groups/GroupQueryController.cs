using dotnet_helpers.Extensions;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.GroupService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LifeTracker.API.Controllers.Groups;

[Route("api/Groups")]
public class GroupQueryController(IGroupQueryService groupQueryService) : BaseController
{

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets the groups linked to the current active user.",
        Description = "Gets the groups linked to the current active user using the HttpContext.",
        OperationId = "GetGroupsForCurrentUser",
        Tags = ["Groups"])]
    public async Task<IActionResult> GetGroupsForCurrentUser()
    {
        var result = await groupQueryService.GetGroupsForCurrentUser();
        return result.ToActionResult();
    }
}