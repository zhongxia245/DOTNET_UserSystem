using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserSystem.Web.Controllers.Filter
{
    public class CheckLoginFilter :FilterAttribute,IActionFilter
    {
        // 摘要:
        //     Called after the action method executes.
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public void OnActionExecuted(ActionExecutedContext filterContext) {
            if (HttpContext.Current.Session["user"] == null)
            {
                try
                {
                    filterContext.Result = new RedirectResult("/Login/login");
                }
                catch (Exception)
                {
                    filterContext.Result = new RedirectResult("/Common/Error");
                }
            }
        }
        //
        // 摘要:
        //     Called before an action method executes.
        //
        // 参数:
        //   filterContext:
        //     The filter context.
        public void OnActionExecuting(ActionExecutingContext filterContext)
        { 
        
        }
    }

}