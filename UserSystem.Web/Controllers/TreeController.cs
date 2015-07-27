using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSystem.Commom;

namespace UserSystem.Web.Controllers
{
    public class TreeController : Controller
    {
        //
        // GET: /Tree/
        private UserSystem.Business.Menu bll = new UserSystem.Business.Menu();

        public ActionResult Index()
        {
            string json = string.Empty;
            json = @"[{
						""id"":1,
						""text"":""用户管理"",
						""attributes"":{
							""p1"":""Custom Attribute1"",
							""p2"":""Custom Attribute2"", 
                            ""url"":""/Home/UserManage""
							}
						},{
                           ""id"":2,
						""text"":""用户查询"",
						""attributes"":{
							""p1"":""Custom Attribute1"",
							""p2"":""Custom Attribute2"", 
                            ""url"":""/Home/UserSearch"" 
                        }
                    }]";
            return Content(json);
        }

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenu()
        {
            string type = Request.QueryString["type"];
            string json = string.Empty;
            json = JsonHelper.ToJson(bll.GetMenu(type));
            return Content(json);
        }



    }
}
