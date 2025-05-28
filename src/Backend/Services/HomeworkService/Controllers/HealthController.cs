using Microsoft.AspNetCore.Mvc;

namespace HomeworkService.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new 
        { 
            status = "healthy",
            service = "HomeworkService",
            timestamp = DateTime.UtcNow
        });
    }
}
