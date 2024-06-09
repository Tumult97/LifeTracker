using dotnet_helpers.Extensions;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.GroupService;
using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LifeTracker.API.Controllers.Groups;

[Route("api/Group")]
public class GroupCommandController(IGroupCommandService groupCommandService) : BaseController
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "",
        Description = "",
        OperationId = "CreateGroup",
        Tags = ["Groups"])]
    public async Task<IActionResult> CreateGroup([FromBody] GroupCreationRequest groupCreationRequest)
    {
        var result = await groupCommandService.CreateGroup(groupCreationRequest);
        return Ok(result.Data);
    }
}