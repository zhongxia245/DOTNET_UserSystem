using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        UserSystem.Business.User userBussiness = new UserSystem.Business.User();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUser()
        {
            int res = 0;
            string name = Request.Form["name"];
            string pwd = Request.Form["pwd"];

            if (string.IsNullOrEmpty(name))
            {
                res = -1;
            }
            else
            {
                UserSystem.Model.User u = new Model.User();
                u.Name = name;
                u.Password = pwd;
                u.AddTime = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss");
                res = userBussiness.Add(u);
            }
            return Content(res.ToString());
        }

        /// <summary>
        /// 获取用户信息（写死的）
        /// </summary>
        /// <returns></returns>
        public ActionResult ReadUser()
        {
            string data = string.Empty;
            data = @"{""total"":28,""rows"":[
    {""ID"":""FI-SW-01"",""Name"":""Koi"",""Password"":10.00,""AddTime"":""P"",""listprice"":36.50,""attr1"":""Large"",""itemid"":""EST-1""},
    {""ID"":""K9-DL-01"",""Name"":""Dalmation"",""Password"":12.00,""AddTime"":""P"",""listprice"":18.50,""attr1"":""Spotted Adult Female"",""itemid"":""EST-10""},
    {""ID"":""RP-SN-01"",""Name"":""Rattlesnake"",""Password"":12.00,""AddTime"":""P"",""listprice"":38.50,""attr1"":""Venomless"",""itemid"":""EST-11""},
    {""ID"":""RP-SN-01"",""Name"":""Rattlesnake"",""Password"":12.00,""AddTime"":""P"",""listprice"":26.50,""attr1"":""Rattleless"",""itemid"":""EST-12""},
    {""ID"":""RP-LI-02"",""Name"":""Iguana"",""Password"":12.00,""AddTime"":""P"",""listprice"":35.50,""attr1"":""Green Adult"",""itemid"":""EST-13""},
    {""ID"":""FL-DSH-01"",""Name"":""Manx"",""Password"":12.00,""AddTime"":""P"",""listprice"":158.50,""attr1"":""Tailless"",""itemid"":""EST-14""},
    {""ID"":""FL-DSH-01"",""Name"":""Manx"",""Password"":12.00,""AddTime"":""P"",""listprice"":83.50,""attr1"":""With tail"",""itemid"":""EST-15""},
    {""ID"":""FL-DLH-02"",""Name"":""Persian"",""Password"":12.00,""AddTime"":""P"",""listprice"":23.50,""attr1"":""Adult Female"",""itemid"":""EST-16""},
    {""ID"":""FL-DLH-02"",""Name"":""Persian"",""Password"":12.00,""AddTime"":""P"",""listprice"":89.50,""attr1"":""Adult Male"",""itemid"":""EST-17""},
    {""ID"":""AV-CB-01"",""Name"":""Amazon Parrot"",""Password"":92.00,""AddTime"":""P"",""listprice"":63.50,""attr1"":""Adult Male"",""itemid"":""EST-18""}
]}
";
            return Content(data);
        }

        /// <summary>
        /// 加载用户信息，从数据库加载
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadUser()
        {
            var pageNum = Convert.ToInt32(Request.Form["page"]);
            var rowNum = Convert.ToInt32(Request.Form["rows"]);
            System.Data.DataSet ds = userBussiness.GetAllList(pageNum, rowNum);
            int total = userBussiness.GetAllList().Tables[0].Rows.Count;
            string json = UserSystem.Commom.JsonHelper.ToJson(ds.Tables[0], total);
            return Content(json);
        }

        //批量删除用户
        public ActionResult DelUser()
        {
            UserSystem.Business.User bllUser = new Business.User();
            bool flag = false;
            var ids = Request.Form["ids"];
            //批量删除（where id in ({0})）
            flag = bllUser.DeleteList(ids);
            return Content(flag.ToString());
        }

        /// <summary>
        /// 根据Name过滤数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDataByName()
        {
            UserSystem.Business.User bllUser = new Business.User();
            var name = Request.QueryString["name"];
            DataTable dt = bllUser.GetList(string.Format("Name like '{0}%'", name)).Tables[0];
            string json = UserSystem.Commom.JsonHelper.ToJson(dt);
            return Content(json);
        }

        /// <summary>
        /// 根据Name过滤数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Update()
        {
            UserSystem.Business.User bllUser = new Business.User();

            var name = Request.Form["name"];
            var pwd = Request.Form["pwd"];
            var id = Request.Form["id"];

            UserSystem.Model.User u = new Model.User();
            u.Name = name;
            u.Password = pwd;
            u.ID = Convert.ToInt32(id);

            bool flag =  bllUser.Update(u);

            return Content(flag.ToString());
        }

    }
}
