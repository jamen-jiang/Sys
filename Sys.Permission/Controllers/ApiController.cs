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
        
        private ICmdService CmdSvc = Container.Resolve<ICmdService>();
        /// <summary>
        /// api入口
        /// </summary>
        /// <param name="code"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public ActionResult ProcessRequest(string code , FormCollection fc)
        {
            string token = Request.Headers.Get("token");
            if (string.IsNullOrEmpty(code))
            {
               return ApiActionResult.ErrorResult((int)StatusCodeEnum.FAIL_CODE);
            }
            ApiRoute api = ApiRouteList.Where(w => w.Code == code).FirstOrDefault();
            if (api == null)
            {
                return ApiActionResult.ErrorResult((int)StatusCodeEnum.FAIL_CODE);
            }
            if (!api.IsPublic)
            {
                if (token == null)
                {
                    return ApiActionResult.ErrorResult((int)StatusCodeEnum.FAIL_TOKEN_UNVALID);
                }
                Payload payload;
                if (!JwtUtils.TryGetJwtDecode<Payload>(token, out payload))
                {
                    return ApiActionResult.ErrorResult((int)StatusCodeEnum.EXPIRED_TOKEN_UNVALID);
                }
                TokenSession ts = Helper.Deserialize<TokenSession>(payload.data.ToString());
                int count = ts.ApiRouteList.Count(c => c.Code == code);
                if (count <= 0)
                    return ApiActionResult.ErrorResult((int)StatusCodeEnum.FAIL_PERMISSION);
                fc.Add("UserId", ts.UserId.ToString());
            }
            foreach (string key in Request.QueryString.AllKeys)
            {
                fc.Add(key, Request.QueryString[key]);
            }
            Dictionary<string, object> dict = new Dictionary<string, object>();
            fc.CopyTo(dict);
            object r = CmdSvc.Execute(api, dict);
            ApiActionResult result = new ApiActionResult();
            HttpApiResponse response = new HttpApiResponse();
            response = r as HttpApiResponse;
            if (response == null)
            {
                result.HttpApiResponse.Data = r;
            }
            else
            {
                result.HttpApiResponse = response;
            }
            return result;
        }
    }
}