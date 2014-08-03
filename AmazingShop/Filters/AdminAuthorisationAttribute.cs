using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazingShop.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AdminAuthorisationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookies = filterContext.RequestContext.HttpContext.Request.Cookies;

            var authCookie = cookies.Get("auth");

            if (authCookie != null && authCookie.Value == "Administrator")
            {
                base.OnActionExecuting(filterContext);
            }
            else
                filterContext.Result = new RedirectResult("/Administration/Index");
        }
    }
}