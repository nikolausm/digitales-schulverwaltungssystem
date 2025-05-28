using Microsoft.AspNetCore.Mvc;
using HomeworkService.DTOs;
using HomeworkService.Services;

namespace HomeworkService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeworkController : ControllerBase
{
    private readonly IHomeworkService _homeworkService;

    public HomeworkController(IHomeworkService homeworkService)
    {
        _homeworkService = homeworkService ?? throw new ArgumentNullException(nameof(homeworkService));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHomework(Guid id)
    {
        var homework = await _homeworkService.GetHomeworkByIdAsync(id);
        if (homework == null)
            return NotFound();
            
        return Ok(homework);
    }

    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetHomeworkByClass(Guid classId)
    {
        var homeworks = await _homeworkService.GetHomeworkByClassAsync(classId);
        return Ok(homeworks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHomework([FromBody] CreateHomeworkRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var homework = await _homeworkService.CreateHomeworkAsync(request);
        return CreatedAtAction(nameof(GetHomework), new { id = homework.Id }, homework);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHomework(Guid id, [FromBody] UpdateHomeworkRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var updated = await _homeworkService.UpdateHomeworkAsync(id, request);
        if (updated == null)
            return NotFound();
            
        return Ok(updated);
    }
}
