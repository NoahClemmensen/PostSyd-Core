using MVC_App.Interfaces;
using MVC_App.Models;

namespace MVC_App.Services;

public class UserService(IDatabaseService databaseService, ILogger<IUserService> logger) : IUserService
{
    public async Task<UserMetadata?> GetUserMetadata(string username)
    {
        logger.LogDebug("Retrieving user metadata for {Username}", username);
        var user = await databaseService.GetUserByUsername(username);
        if (user == null)
        {
            logger.LogError($"User {username} not found");
            return null;
        }
        
        if (user.DepartmentId == null)
        {
            logger.LogError($"User {username} has no department ID");
            return null;
        }

        var department = await databaseService.GetDepartmentById((int)user.DepartmentId);
        if (department != null)
            return new UserMetadata
            {
                Username = username,
                Terminal = department.Name
            };
        
        logger.LogError($"Department not found for user {username}");
        return null;
    }

    public bool IsLoggedIn(HttpContext context)
    {
        try
        {
            foreach (var (cookie, value) in context.Request.Cookies)
            {
                if (cookie == "loggedIn" && value == "true")
                {
                    return true;
                }
            }
        } catch (Exception e) {
            logger.LogError(e, "Error checking if user is logged in");
        }

        return false;
    }
}