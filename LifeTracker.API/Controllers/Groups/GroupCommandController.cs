using dotnet_helpers.Extensions;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.GroupService;
using LifeTracker.Application.Services.Entities.GroupService.Interfaces;
using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LifeTracker.API.Controllers.Groups;

[Route("api/Groups")]
public class GroupCommandController(IGroupCommandService groupCommandService) : BaseController
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "",
        Description = "",
        OperationId = "CreateGroup",
        Tags = ["Groups"])]
    public IActionResult CreateGroup([FromBody] GroupCreationRequest groupCreationRequest)
    {
        var result = groupCommandService.CreateGroup(groupCreationRequest);
        return Ok(result.Data);
    }
}