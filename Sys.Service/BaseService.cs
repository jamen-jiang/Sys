using Sys.Common;
using Sys.Domain;
using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public abstract class BaseService
    {
        public ApiRequest Request { get; set; }
        /// <summary>
        /// API上下文信息
        /// </summary>
        public ApiWorkContext WorkContext
        {
            get
            {
                return Request.ApiWorkContext;
            }
        }
        protected SysContext NewDB()
        {
            return new SysContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("ServiceBase.Try", ex);
            }
        }
        /// <summary>
        /// 把Post数据参数转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ConvertToModel<T>() where T : class
        {
            T t;
            try
            {
                //UnixDateTimeConverter utc = new UnixDateTimeConverter();
                t = Utils.Deserialize<T>(Request.Params.ToString());
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }

            // 判断参数是否可以为空
            //Type objType = typeof(T);
            //// 首先获取类上的特性 
            ////var classAttribute = objType.GetCustomAttribute(typeof(APIRequired), true) as APIRequired;
            //// 取属性上的自定义特性
            //foreach (PropertyInfo propInfo in objType.GetProperties())
            //{
            //    // 获取属性的验证特性，如果属性设置了，则忽略类设置的验证特性
            //    //object[] objAttrs = propInfo.GetCustomAttributes(typeof(APIRequired), true);
            //    //if (objAttrs.Length > 0)
            //    //{
            //    //    if (!(objAttrs[0] as APIRequired).Required)
            //    //    {
            //    //        continue;
            //    //    }
            //    //}
            //    //// 属性没有设置验证特性，则需要判断类中的验证特性
            //    //else
            //    //{
            //    //    if (classAttribute == null || !classAttribute.Required)
            //    //    {
            //    //        continue;
            //    //    }
            //    //}
            //    object value = propInfo.GetValue(t);
            //    if (propInfo.PropertyType == typeof(string) || propInfo.PropertyType == typeof(DateTime))
            //    {
            //        if (string.IsNullOrEmpty(Convert.ToString(value)))
            //        {
            //            throw new ApiException(propInfo.Name + "参数不能为空");
            //        }
            //        if (propInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(Convert.ToString(value)) == DateTime.MinValue)
            //        {
            //            throw new ApiException(propInfo.Name + "参数不能为空");
            //        }
            //    }
            //}
            return t;
        }
    }
}
