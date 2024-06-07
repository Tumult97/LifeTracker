using LifeTracker.API.Controllers.Base;
using LifeTracker.Domain.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace LifeTracker.API.Controllers.Authentication;

[Route("api/Authentication")]
public class RegistrationController : BaseController
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterRequestModel requestModel)
    {
        return Ok();
    }
}