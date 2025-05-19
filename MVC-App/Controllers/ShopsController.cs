using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopsController : Controller
{
    private readonly ILogger<ShopsController> _logger;
    private readonly IDatabaseService _dbService;

    public ShopsController(ILogger<ShopsController> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    [HttpGet]
    [HttpGet("All")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Fetching all shops.");
        var shops = await _dbService.GetShops();
        _logger.LogInformation("Successfully fetched {Count} shops.", shops.Count());
        return Ok(shops);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Fetching shop with ID {Id}.", id);
        var shop = await _dbService.GetShopById(id);
        if (shop == null)
        {
            _logger.LogWarning("Shop with ID {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Successfully fetched shop with ID {Id}.", id);
        return Ok(shop);
    }
}