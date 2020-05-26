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
        /// <param name="code"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public ActionResult ProcessRequest()
        {
            Request.Params.Add("Token", Request.Headers.Get("token"));
            // 解析 Post Json 参数 
            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string reqParams = System.Text.Encoding.UTF8.GetString(byts);
            ApiActionResult result = new ApiActionResult();
            ApiResponse response = Main.Process(reqParams);
            result.Response = response;
            return result;
        }
    }
}