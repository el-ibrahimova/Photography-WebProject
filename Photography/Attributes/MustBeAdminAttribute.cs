﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Photography.Controllers;
using Photography.Core.Interfaces;
using Photography.Extensions;

namespace Photography.Attributes
{
    public class MustBeAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (userService == null)
            {
                context.Result = new RedirectToActionResult(nameof(HomeController.Error), "Home", new { statusCode = 500 });
                return;
            }

            if (userService != null
                && userService.UserExistByIdAsync(Guid.Parse(context.HttpContext.User.GetUserId())).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(HomeController.Error), "Home", new { statusCode = 403 });
                return;
            }
        }
    }
}