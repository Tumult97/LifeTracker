using dotnet_helpers.Extensions;
using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LifeTracker.API.Controllers.Authentication;

[Route("api/Authentication")]
public class LoginController(IConfiguration config, IUserQueryService userQueryService) : BaseController
{
    [AllowAnonymous]
    [HttpGet]
    [SwaggerOperation(
        Summary = "Login to the application.",
        Description = "Login to the application.",
        OperationId = "Login",
        Tags = ["Authentication"])]
    public async Task<IActionResult> Login([FromQuery] LoginRequestModel loginRequestModel)
    {
        var serviceResult = await userQueryService.Login(loginRequestModel);

        return serviceResult.ToActionResult();
    }
}