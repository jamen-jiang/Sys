using Sys.Common;
using Sys.Domain;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sys.Permission.Controllers
{
    public class BaseController : Controller
    {
        //protected HttpContextBase HttpContext
        //{
        //    get
        //    {
        //        HttpContextWrapper context =
        //        new HttpContextWrapper(System.Web.HttpContext.Current);
        //        return context;
        //    }
        //}
        //protected List<ApiRoute> ApiRouteList 
        //{
        //    get
        //    {
        //        if (HttpSession.Get(Config.API_KEY) != null)
        //            return HttpSession.Get(Config.API_KEY) as List<ApiRoute>;
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        HttpSession.Set(Config.API_KEY, value);
        //    }
        //}
        //public BaseController()
        //{
        //    this.GetApiRoute();
        //}
        protected override void Initialize(RequestContext requestContext)
        {
            //string token = requestContext.HttpContext.Request.Headers.Get("token");
            //if (!string.IsNullOrEmpty(token))
            //    requestContext.HttpContext.Request.Form["Token"] = token;
            //requestContext.HttpContext.Request.Params.Add("Token", token);
            base.Initialize(requestContext);
            //HttpRequestBase request = requestContext.HttpContext.Request;//定义传统request对象
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);
            // 标记异常已处理
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.HttpContext.Response.StatusDescription = "OK";
            Exception ex = filterContext.Exception;
            do
            {
                if (ex is System.Reflection.TargetInvocationException)
                {
                    
                }
                else if (ex is ApiException)
                {
                    break;
                }
                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                else
                {
                    break;
                }
            }
            while (ex != null);
            LogHelper.Default.Error("请求处理异常" + ex.Message, ex);
            ActionResult result = ExceptionProcess(ex);
            filterContext.Result = result;
        }
        protected virtual ActionResult ExceptionProcess(Exception ex)
        {
            ApiActionResult result = new ApiActionResult();
            if (ex is ApiException)
            {
                ApiException apiException = ex as ApiException;
                result.Response.Status = apiException.Code;
                result.Response.Message = apiException.Message;
            }
            else
            {
                result.Response.Status = (int)ApiStatusEnum.FAIL_EXCEPTION;
                result.Response.Message = "系统错误";
            }
            return result;
        }
        //public void GetApiRoute()
        //{
        //    if (this.ApiRouteList != null)
        //        return;
        //    //string dir = HttpContext.Server.MapPath(string.Format("{0}/Config/ApiRoute", HttpContext.Request.ApplicationPath));
        //    //string[] files = Directory.GetFiles(dir);
        //    //List<ApiRoute> li = new List<ApiRoute>();
        //    //foreach (string file in files)
        //    //{
        //    //    if (file.IndexOf(".xml") == -1)
        //    //        continue;
        //    //    li.AddRange(XMLHelper.DeSerializeXML<List<ApiRoute>>(file));
        //    //    try
        //    //    {
        //    //        li.AddRange(XMLHelper.DeSerializeXML<List<ApiRoute>>(file));
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        throw new ApplicationException(file + "文件格式错误");
        //    //    }
        //    //}
        //    this.ApiRouteList = apiSvc.GetApiRouteList();
        //}
    }
}