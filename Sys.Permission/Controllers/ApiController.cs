using Sys.Common;
using Sys.Domain;
using Sys.IService;
using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Sys.Permission.Controllers
{
    public class ApiController : BaseController
    {
        /// <summary>
        /// api入口
        /// </summary>
        /// <returns></returns>
        public ActionResult ProcessRequest()
        {
            // 解析 Post Json 参数 
            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string reqParams = System.Text.Encoding.UTF8.GetString(byts);
            ApiResponse response = Main.Process(reqParams);
            ApiActionResult result = new ApiActionResult();
            result.Response = response;
            return result;
        }
    }
}