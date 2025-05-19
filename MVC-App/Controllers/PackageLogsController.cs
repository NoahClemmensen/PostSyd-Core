using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageLogsController : Controller
{
    private readonly ILogger<PackageLogsController> _logger;
    private readonly IDatabaseService _dbService;

    public PackageLogsController(ILogger<PackageLogsController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all package logs.");
        var logs = await _dbService.GetPackageLogs();
        _logger.LogInformation("Successfully fetched {Count} package logs.", logs.Count());
        return Ok(logs);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Fetching package log with ID {Id}.", id);
        var log = await _dbService.GetPackageLogById(id);
        if (log == null)
        {
            _logger.LogWarning("Package log with ID {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched package log with ID {Id}.", id);
        return Ok(log);
    }
}