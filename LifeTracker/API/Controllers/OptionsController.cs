using Config.Options;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetApplicationOptionsValueByKey([FromServices] IOptionsMonitor<ApplicationOptions> applicationOptions, [FromQuery] string key)
    {
        var appOptions = applicationOptions.CurrentValue;
        var value = typeof(ApplicationOptions).GetProperty(key)?.GetValue(appOptions);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult UpdateValue(
        [FromServices] IOptionsMonitor<ApplicationOptions> applicationOptions, 
        [FromQuery] string key, 
        [FromQuery] string newValue)
    {
        var appOptions = applicationOptions.CurrentValue;
        typeof(ApplicationOptions).GetProperty(key)?.SetValue(appOptions, newValue);
        return Ok();
    }
    
}