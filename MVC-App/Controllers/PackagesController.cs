using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[Route("[controller]")]
public class PackagesController : Controller
{
    private readonly ILogger<PackagesController> _logger;
    private readonly IDatabaseService _dbService;

    public PackagesController(ILogger<PackagesController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }
    
    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Fetching all packages for the index page.");
        var packages = await _dbService.GetPackages();
        _logger.LogInformation("Successfully fetched {Count} packages for the index page.", packages.Count());
        return View(packages);
    }

    [HttpGet("Overview/{id}")]
    public async Task<IActionResult> Overview(int id)
    {
        var package = await _dbService.GetPackageById(id);
        if (package == null)
        {
            _logger.LogWarning("Package with ID {Id} not found for overview.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched package with ID {Id} for overview.", id);
        return View(package);
    }
}