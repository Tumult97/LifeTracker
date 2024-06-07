using LifeTracker.API.Controllers.Base;
using LifeTracker.Application.Services.Entities.UserService.Interfaces;
using LifeTracker.Domain.Models.API;
using LifeTracker.Infrastructure.Command_Managers.User;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.API.Controllers.Authentication;

[Route("api/Authentication")]
public class RegistrationController(IUserCommandService userCommandService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestModel requestModel)
    {
        var result = await userCommandService.RegisterUserAsync(requestModel);

        return Ok(result);
    }
}