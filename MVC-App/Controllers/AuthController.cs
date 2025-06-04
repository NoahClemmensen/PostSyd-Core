using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(ILogger<AuthController> logger, IAuthService authService, IDatabaseService databaseService) : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    [Route("Login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return BadRequest("Username and password are required.");
        }

        var token = await authService.Authenticate(username, password);
        if (token == null)
        {
            logger.LogWarning("Authentication failed for user {Username}", username);
            return Unauthorized();
        }

        logger.LogInformation("User {Username} authenticated successfully", username);
        return Ok(new { Token = token });
    }
    
    // This action is just for demonstration purposes
    [HttpPost]
    [Route("newUser")]
    public async Task<IActionResult> NewUser(string username, string password)
    {
        var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        if (encryptedPassword == null)
        {
            logger.LogError("Password encryption failed for user {Username}", username);
            return BadRequest("Password encryption failed");
        }

        try
        {
            await databaseService.CreateUser(username, encryptedPassword, 1);
            var newUser = await databaseService.GetUserByUsername(username);
            if (newUser == null)
            {
                logger.LogError("User creation failed for {Username}", username);
                return BadRequest("User creation failed");
            }
            
            logger.LogInformation("New user {Username} created successfully", username);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating new user {Username}", username);
            return StatusCode(500, "Internal server error");
        }
    }
}