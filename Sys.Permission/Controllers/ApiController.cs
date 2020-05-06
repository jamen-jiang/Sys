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
            HttpApiResponse response = new HttpApiResponse();
            string token = Request.Headers.Get("token");
            if (string.IsNullOrEmpty(code))
                throw new ApplicationException(HttpStatusCode.FAIL_CODE.ToString());
            ApiRoute api = ApiRouteList.Where(w => w.Code == code).FirstOrDefault();
            if (api == null)
                throw new ApplicationException(HttpStatusCode.FAIL_CODE.ToString());
            if (!api.IsPublic)
            {
                if (token == null)
                    throw new ApplicationException(HttpStatusCode.FAIL_TOKEN_UNVALID.ToString());
                Payload payload = JwtUtils.GetJwtDecode<Payload>(token);
                TokenSession ts = Helper.Deserialize<TokenSession>(payload.data.ToString());
                int count = ts.ApiRouteList.Count(c => c.Code == code);
                if (count <= 0)
                    throw new ApplicationException(HttpStatusCode.FAIL_PERMISSION.ToString());
                fc.Add("UserId", ts.UserId.ToString());
            }
            foreach (string key in Request.QueryString.AllKeys)
            {
                fc.Add(key, Request.QueryString[key]);
            }
            
            Dictionary<string, object> dict = new Dictionary<string, object>();
            fc.CopyTo(dict);
            object r = CmdSvc.Execute(api, dict);
            response = r as HttpApiResponse;
            ApiActionResult result = new ApiActionResult();
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