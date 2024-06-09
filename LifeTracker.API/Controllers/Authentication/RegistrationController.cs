using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LifeTracker.API.Controllers.Authentication;

[Route("api/Authentication")]
public class RegistrationController(IUserCommandService userCommandService) : BaseController
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "User Registration endpoint.",
        Description = "Logic that houses the registration, hash generation and storage of a new user.",
        OperationId = "RegisterUser",
        Tags = ["Authentication"])]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestModel requestModel)
    {
        var result = await userCommandService.RegisterUserAsync(requestModel);

        return Ok(result);
    }
}