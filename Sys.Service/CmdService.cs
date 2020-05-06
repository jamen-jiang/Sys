using Sys.Common;
using Sys.Domain;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class CmdService : ICmdService
    {
        /// <summary>
        /// 执行接口的方法获取返回值
        /// </summary>
        /// <param name="api"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public object Execute(ApiRoute api, Dictionary<string, object> dict)
        {
            //获取接口
            Assembly assembly = Assembly.Load(api.AssemblyName);
            Type type = assembly.GetType(api.ClassName);
            //获取注入的接口
            object serviceObj = Container.Resolve(type);
            Type service = serviceObj.GetType();
            //获取方法
            MethodInfo method = service.GetMethod(api.MethodName);
            if (method != null)
            {
                List<object> li = new List<object>();
                ParameterInfo[] parameters = method.GetParameters();
                Type param = parameters[0].ParameterType;
                object obj = Helper.Dictionary2Model(param, dict);
                li.Add(obj);
                //调用Service的方法
                object response = method.Invoke(serviceObj, li.ToArray());
                return response;
            }
            return null;
        }
    }
}
