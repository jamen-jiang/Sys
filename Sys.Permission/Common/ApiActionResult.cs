﻿using Sys.Common;
using Sys.Domain;
using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sys.Permission
{
    public class ApiActionResult: ActionResult
    {
        /// <summary>
        /// 输出编码
        /// </summary>
        protected Encoding Encoder { get; set; }
        public ApiResponse Response { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            string jsonText = Utils.Serialize(Response);
            //处理null值
            jsonText = jsonText.Replace("null", "\"\"");
            //FrameWork.LoggerManager.Warn(string.Format("请求返回,Reponse-{0}", jsonText));
            context.HttpContext.Response.ContentEncoding = Encoder;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.Write(jsonText);
            context.HttpContext.Response.End();
        }
        public ApiActionResult()
        {
            Response = new ApiResponse();
            Encoder = Encoding.UTF8;
        }
    }
}