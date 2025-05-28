using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MVC_App.Interfaces;

namespace MVC_App.Services;

public class AuthService(string secret, string issuer, string audience, IDatabaseService databaseService) : IAuthService
{
    public string? GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secret);

        try
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer =  issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            return principal;
        }
        catch
        {
            return null;
        }
    }
    
    public void SetToken(HttpContext context, string token)
    {
        context.Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });
    }

    public string? GetToken(HttpContext context)
    {
        try
        {
            foreach (var (cookie, _) in context.Request.Cookies)
            {
                if (cookie == "jwt")
                {
                    return cookie;
                }
            }
        } catch (Exception) {
            return null;
        }
        
        return null;
    }

    public async Task<string?> Authenticate(string username, string password)
    {
        var user = await databaseService.GetUserByUsername(username);
        if (user == null) 
        {
            return null;
        }
        
        var result = BCrypt.Net.BCrypt.Verify(password, user.Password);
        return result ? GenerateToken(username) : null;
    }
}