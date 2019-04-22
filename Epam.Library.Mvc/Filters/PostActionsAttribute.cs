using BL_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Epam.Library.Mvc.Filters
{

    public class PostActionsAttribute : FilterAttribute, IActionFilter
    {
        private readonly ILogger logger;

        public PostActionsAttribute()
        {
            this.logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (Roles.IsUserInRole("Admin"))
                {
                    logger.Warning("Administrator did actions", $"Epam.Library.WebUI.{filterContext.ActionDescriptor.ControllerDescriptor}.{filterContext.ActionDescriptor.ActionName}");
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}