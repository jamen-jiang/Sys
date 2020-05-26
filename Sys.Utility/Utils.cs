using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sys.Utility
{
    public static class Utils
    {
        /// <summary>
        /// ToJSON扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJSON<T>(this T t)
        {
            return Utils.Serialize(t);
        }


        public static T GetEnum<T>(string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase = true);
        }
        public static string GetEnumName<T>(string value, bool ignoreCase = true)
        {
            var t = (T)Enum.Parse(typeof(T), value, ignoreCase);
            System.Reflection.FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return t.ToString();
            else
                return (attribArray[0] as System.ComponentModel.DescriptionAttribute).Description;
        }
        public static string GetEnumName(Type enumType, string value, bool ignoreCase = true)
        {
            var t = Enum.Parse(enumType, value, ignoreCase);
            System.Reflection.FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return t.ToString();
            else
                return (attribArray[0] as System.ComponentModel.DescriptionAttribute).Description;

        }
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
    }
}
