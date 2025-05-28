using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVC_App.Interfaces;

namespace MVC_App.Controllers;

public class BaseController(IAuthService authService) : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var token = authService.GetToken(context.HttpContext);
        if (string.IsNullOrEmpty(token) || authService.ValidateToken(token) == null)
        {
            context.Result = new RedirectToActionResult("Login", "Auth", null);
        }

        base.OnActionExecuting(context);
    }
}