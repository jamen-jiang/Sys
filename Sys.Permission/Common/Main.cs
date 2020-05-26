using Sys.Common;
using Sys.Domain;
using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sys.Permission
{
    public class Main
    {
        public static ApiResponse Process(string reqParams)
        {
            // 设置全局的Code名称，在报错时把Cmd值返回
            string globalCode = string.Empty;
            // 获取json转化的对象 
            ApiRequest request = null;
            try
            {
                // 转换成JSON对象
                request = Utils.Deserialize<ApiRequest>(reqParams);
            }
            catch
            {
                throw new ApiException("JSON格式不正确");
            }
            // 判断是否转换成正确的对象
            if (request == null)
            {
                throw new ApiException("参数格式不正确");
            }
            if (string.IsNullOrEmpty(request.Code))
            {
                throw new ApiException((int)ApiStatusEnum.FAIL_CODE);
            }
            globalCode = request.Code;
            //接口名称
            string serviceName;
            //方法名称
            string methodName;
            if (!globalCode.Contains("_"))
            {
                serviceName = "Common";
                methodName = globalCode;
            }
            else
            {
                string[] codes = globalCode.Split('_');
                serviceName = codes[0];
                methodName = codes[1];
            }
            //获取类名称
            string fullName = string.Format("Sys.IService.I{0}Service", serviceName);
            //根据类名获取实例
            var t = Type.GetType(fullName, false, true);
            if (t == null)
            {
                throw new ApiException((int)ApiStatusEnum.FAIL_CODE);
            }
            //获取注入的接口
            object serviceObj = Container.Resolve(t);
            Type service = serviceObj.GetType();
            //获取方法
            MethodInfo method = service.GetMethod(methodName);
            APINotNeedToken nt = (APINotNeedToken)Attribute.GetCustomAttribute(method, typeof(APINotNeedToken));
            if (nt == null || (!nt.NotNeedToken))
            {
                //如果需要验证  
                if (request.Token == null)
                {
                    throw new ApiException((int)ApiStatusEnum.FAIL_TOKEN_UNVALID);
                }
                Payload payload;
                if (!JwtUtils.TryGetJwtDecode(request.Token, out payload))
                {
                    throw new ApiException((int)ApiStatusEnum.EXPIRED_TOKEN_UNVALID);
                }
                TokenSession ts = Utils.Deserialize<TokenSession>(payload.data.ToString());
                request.ApiWorkContext = new ApiWorkContext();
                request.ApiWorkContext.UserId = ts.UserId;
            }
            //为接口的属性Request赋值
            PropertyInfo requestInfo = service.GetProperty("Request");
            requestInfo.SetValue(service, request, null);
            //调用Service的方法
            object response = method.Invoke(serviceObj, null);
            return (ApiResponse)response;
        }
    }
}