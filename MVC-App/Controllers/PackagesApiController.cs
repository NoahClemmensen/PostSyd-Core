using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("/api/Packages")]
public class PackagesApiController : Controller
{
    private readonly ILogger<PackagesController> _logger;
    private readonly IDatabaseService _dbService;

    public PackagesApiController(ILogger<PackagesController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }
    
    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all packages.");
        var packages = await _dbService.GetPackages();
        _logger.LogInformation("Successfully fetched {Count} packages.", packages.Count());
        return Ok(packages);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Fetching package with ID {Id}.", id);
        var package = await _dbService.GetPackageById(id);
        if (package == null)
        {
            _logger.LogWarning("Package with ID {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched package with ID {Id}.", id);
        return Ok(package);
    }
}