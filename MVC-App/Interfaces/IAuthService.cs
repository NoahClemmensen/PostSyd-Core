using System.Security.Claims;

namespace MVC_App.Interfaces;

public interface IAuthService
{
    string? GenerateToken(string username);
    ClaimsPrincipal? ValidateToken(string token);
    void SetToken(HttpContext context, string token);
    string? GetToken(HttpContext context);
    Task<string?> Authenticate(string username, string password);
}