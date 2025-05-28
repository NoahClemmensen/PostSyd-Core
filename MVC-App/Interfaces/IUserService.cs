using MVC_App.Models;

namespace MVC_App.Interfaces;

public interface IUserService
{
    Task<UserMetadata?> GetUserMetadata(string username);
    bool IsLoggedIn(HttpContext context);
}