using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;
using MVC_App.Models;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(ILogger<TestController> logger, IDatabaseService dbService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        logger.LogInformation("Tralaleo Tralala");
        return Ok("message");
    }

    [HttpPost("post/{id}")]
    public IActionResult PostWithRouteData(int id)
    {
        return Ok($"Received ID: {id}");
    }
    
    [HttpPost("post-form")]
    public IActionResult PostFormData([FromForm] string name, [FromForm] int age)
    {
        return Ok($"Received Name: {name}, Age: {age}");
    }
    
    [HttpPost("post-model")]
    public IActionResult PostModelData([FromBody] TestModel model)
    {
        if (model.Age < 18)
        {
            return BadRequest("Age must be at least 18.");
        }
        
        if (string.IsNullOrEmpty(model.Name))
        {
            return BadRequest("Name cannot be empty.");
        }
        
        return Ok($"Received Name: {model.Name}, Age: {model.Age}");
    }
}