using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController(ILogger<DepartmentsController> logger, IDatabaseService dbService)
    : Controller
{
    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        var departments = await dbService.GetDepartments();
        return Ok(departments);
    }
    
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await dbService.GetDepartmentById(id);
        if (department == null)
        {
            return NotFound();
        }
        return Ok(department);
    }
}