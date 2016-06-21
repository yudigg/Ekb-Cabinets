using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;

namespace MvcEKCabinets.Models
{
    public class UserActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            var mgr = new AdminsManager(Properties.Settings.Default.Constr);

            filterContext.Controller.ViewBag.Name = filterContext.HttpContext.User.Identity.Name;
            //  mgr.GetUserByUsername(filterContext.HttpContext.User.Identity.Name);
        }
    }
}