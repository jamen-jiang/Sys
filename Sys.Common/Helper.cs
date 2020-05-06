using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sys.Common
{
    public static class Helper
    {
        #region 序列化和反序列化

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string Serialize<T>(T t)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(t);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string strJson)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Deserialize<T>(strJson);

        }

        #endregion

        #region 时间戳操作
        /// <summary>
        /// 时间戳转成时间类型
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime TimeStamp2DateTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 时间类型转成时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DateTime2TimeStamp(System.DateTime time)
        {
            long timeStamp = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            timeStamp = (long)(time - startTime).TotalSeconds;
            return timeStamp.ToString();
        }
        #endregion
        /// <summary>
        /// 字典转成反射的参数类型
        /// </summary>
        /// <param name="param"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static object Dictionary2Model(Type param, Dictionary<string, object> dict)
        {
            object obj = Activator.CreateInstance(param);
            //根据Key值设定 Columns
            foreach (KeyValuePair<string, object> item in dict)
            {
                PropertyInfo prop = obj.GetType().GetProperty(item.Key);
                if (prop == null)
                    continue;
                if (item.Value != null && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    object value = item.Value;
                    //Nullable 获取Model类字段的真实类型
                    Type itemType = Nullable.GetUnderlyingType(prop.PropertyType) == null ? prop.PropertyType : Nullable.GetUnderlyingType(prop.PropertyType);
                    //根据Model类字段的真实类型进行转换
                    prop.SetValue(obj, Convert.ChangeType(value, itemType), null);
                }
            }
            return obj;
        }
    }
}
