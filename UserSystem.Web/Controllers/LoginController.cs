using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return View();
        }

        Business.User user = new Business.User();        //业务逻辑层User对象

        public ActionResult DoLogin()
        {

            int res = 0;
            string name = Request.Form["name"];
            string pwd = Request.Form["pwd"];
            //代表账号为空 ，正常是不会出现，但是如果用户禁用JS脚本就可能出现
            if (string.IsNullOrEmpty(name))
            {
                res = -1;
            }
            else
            {
                //根据条件回去数据库的数据
                var userList = user.GetModelList(string.Format("name = '{0}' and  password = '{1}'",name,pwd));
                //如果集合条数为0,代表账号或者密码有误 ，否则登录成功
                if (userList.Count == 0)
                {
                    res = -2;
                }
                else
                {
                    //把数据存放到Session中
                    Session["user"] = userList[0];
                }
            }
            return Content(res.ToString());
        }

        public ActionResult DoLogoff() {
            int res = 0;
            try
            {
                Session.RemoveAll();       //如果清除Session成功，返回0
                Session.Clear();
            }
            catch (Exception)
            {
                res = -1;              //清除Session出现异常，返回-1
            }
            return Content(res.ToString());
        }

    }
}
