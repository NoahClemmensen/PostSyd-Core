using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_App.Interfaces;

namespace MVC_App.Filters;

public class UserMetadataFilter(IUserService userService) : IActionFilter
{
    public async void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is not Controller controller) return;
        
        var userMetadata = await userService.GetUserMetadata("noah"); // Replace "noah" with the actual username logic
        var isLoggedIn = userService.IsLoggedIn(context.HttpContext);
            
        controller.ViewData["IsLoggedIn"] = isLoggedIn;
        controller.ViewData["User"] = userMetadata;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // No action needed after the action executes
    }
}