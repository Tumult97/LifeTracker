using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.API.Controllers.Authentication;

public class RegistrationCommandController : AuthController
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterRequestModel requestModel)
    {
        return Ok();
    }
}