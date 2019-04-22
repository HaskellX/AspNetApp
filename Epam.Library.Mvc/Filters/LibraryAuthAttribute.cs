using BL_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace Epam.Library.Mvc.Filters
{
    public class LibraryAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        private readonly ILogger logger;

        public LibraryAuthAttribute()
        {
            this.logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!Roles.IsUserInRole("Admin"))
                {
                    logger.Warning("User tried to access admin functionality", $"Epam.Library.WebUI.{filterContext.ActionDescriptor.ControllerDescriptor}.{filterContext.ActionDescriptor.ActionName}");
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Account" }, { "action", "Login" }
                   });
            }
        }
    }
}