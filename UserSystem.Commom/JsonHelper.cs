using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UserSystem.Commom
{
    public static class JsonHelper
    {
        /// <summary>
        /// 把DataTable转换成JSON格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt)
        {
            string json = string.Empty;
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }

        /// <summary>
        /// 把DataTable转换成JSON格式（包含总条数（total）的格式--EasyUI的DataGrid分页需要用到）
        /// </summary>
        /// <param name="dt">表格</param>
        /// <param name="total">总行数</param>
        /// <returns></returns>
        public static string ToJson(DataTable dt, int total)
        {
            string json = string.Empty;
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            string rowsJson = @"{""total"":" + total + @",""rows"":" + json + "}";
            return rowsJson;
        }
    }
}
