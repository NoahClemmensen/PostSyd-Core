using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : Controller
{
    
    private readonly ILogger<DepartmentsController> _logger;
    private readonly IDatabaseService _dbService;

    public DepartmentsController(ILogger<DepartmentsController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }
    
    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all departments.");
        var departments = await _dbService.GetDepartments();
        _logger.LogInformation("Successfully fetched {Count} departments.", departments.Count());
        return Ok(departments);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Fetching department with ID {Id}.", id);
        var department = await _dbService.GetDepartmentById(id);
        if (department == null)
        {
            _logger.LogWarning("Department with ID {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched department with ID {Id}.", id);
        return Ok(department);
    }
}