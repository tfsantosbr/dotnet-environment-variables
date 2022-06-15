using Microsoft.AspNetCore.Mvc;

namespace EnvironmentVariablesTest.Api.Controllers;

[ApiController]
[Route("environments")]
public class EnvironmentController : ControllerBase
{
    private readonly IConfigurationSection _configuration;

    public EnvironmentController(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("ExternalServiceConfiguration");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Url = _configuration["Url"],
            Username = _configuration["Username"],
            Password = _configuration["Password"]
        });
    }
}
