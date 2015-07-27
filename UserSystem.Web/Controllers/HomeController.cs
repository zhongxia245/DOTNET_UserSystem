using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Web.Controllers.Filter;

namespace UserSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [CheckLoginFilter()]    //添加过滤器，首先会经过过滤器，才会return 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserManage()
        {
            return View();
        }

        public ActionResult UserSearch()
        {
            return View();
        }

    }
}
