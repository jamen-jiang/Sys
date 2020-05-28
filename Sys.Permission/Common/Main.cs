using Newtonsoft.Json;
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
            // 获取json转化的对象 
            ApiRequest request;
            try
            {
                // 转换成JSON对象
                request = JsonConvert.DeserializeObject<ApiRequest>(reqParams);
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
                throw new ApiException(ApiStatusEnum.FAIL_CODE);
            }
            //接口名称
            string serviceName;
            //方法名称
            string methodName;
            if (!request.Code.Contains("_"))
            {
                serviceName = "Common";
                methodName = request.Code;
            }
            else
            {
                string[] codes = request.Code.Split('_');
                serviceName = codes[0];
                methodName = codes[1];
            }
            //获取类名称
            string assemblyName = "Sys.IService";
            string fullName = string.Format(assemblyName + ".I{0}Service", serviceName);
            Assembly assembly = Assembly.Load(assemblyName);
            Type t = assembly.GetType(fullName);
            if (t == null)
            {
                throw new ApiException(ApiStatusEnum.FAIL_CODE);
            }
            //获取注入的接口
            object serviceObj = Container.Resolve(t);
            Type service = serviceObj.GetType();
            //获取方法
            MethodInfo method = service.GetMethod(methodName);
            ApiNotNeedTokenAttribute nt = (ApiNotNeedTokenAttribute)Attribute.GetCustomAttribute(method, typeof(ApiNotNeedTokenAttribute));
            if (nt == null || (!nt.NotNeedToken))
            {
                //如果需要验证  
                if (request.Token == null)
                {
                    throw new ApiException(ApiStatusEnum.FAIL_TOKEN_UNVALID);
                }
                Payload payload;
                if (!JwtUtils.TryGetJwtDecode(request.Token, out payload))
                {
                    throw new ApiException(ApiStatusEnum.EXPIRED_TOKEN_UNVALID);
                }
                TokenSession ts = Utils.Deserialize<TokenSession>(payload.data.ToString());
                request.ApiWorkContext = new ApiWorkContext();
                request.ApiWorkContext.UserId = ts.UserId;
            }
            //为接口的属性Request赋值
            PropertyInfo requestInfo = service.GetProperty("Request");
            requestInfo.SetValue(serviceObj, Convert.ChangeType(request, requestInfo.PropertyType), null);
            //调用Service的方法
            object response = method.Invoke(serviceObj, null);
            return (ApiResponse)response;
        }
    }
}