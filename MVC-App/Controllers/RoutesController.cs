using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutesController : Controller
{
    private readonly ILogger<RoutesController> _logger;
    private readonly IDatabaseService _dbService;

    public RoutesController(ILogger<RoutesController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all routes.");
        var routes = await _dbService.GetRoutes();
        _logger.LogInformation("Successfully fetched {Count} routes.", routes.Count());
        return Ok(routes);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Fetching route with ID {Id}.", id);
        var route = await _dbService.GetRouteById(id);
        if (route == null)
        {
            _logger.LogWarning("Route with ID {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched route with ID {Id}.", id);
        return Ok(route);
    }
}