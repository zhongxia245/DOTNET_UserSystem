using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UserSystem.Business
{
    public class Menu
    {
        private readonly UserSystem.Data.Menu dal = new UserSystem.Data.Menu();

        /// <summary>
        /// 根据菜单的类型，获取菜项信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetMenu(string type)
        {
            DataTable dt =  dal.GetList("type="+type).Tables[0];
            return dt;
        }
    }
}
