using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Photography.Controllers;
using Photography.Core.Interfaces;
using Photography.Extensions;

namespace Photography.Attributes
{
    public class MustBePhotographerAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IPhotographerService? photographerService = context.HttpContext.RequestServices.GetService<IPhotographerService>();

            if (photographerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (photographerService != null
                && photographerService.ExistsByIdAsync(context.HttpContext.User.GetUserId()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(GalleryController.Gallery), "Gallery", null);
            }
        }
    }
}
