using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Utility
{
    public class Utils
    {
        public static T GetEnum<T>(string value, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
        public static string GetEnumName<T>(string value, bool ignoreCase)
        {
            var t = (T)Enum.Parse(typeof(T), value, ignoreCase);
            System.Reflection.FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return t.ToString();
            else
                return (attribArray[0] as System.ComponentModel.DescriptionAttribute).Description;
        }
        public static string GetEnumName(Type enumType, string value, bool ignoreCase)
        {
            var t = Enum.Parse(enumType, value, ignoreCase);
            System.Reflection.FieldInfo fieldInfo = t.GetType().GetField(t.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return t.ToString();
            else
                return (attribArray[0] as System.ComponentModel.DescriptionAttribute).Description;

        }
    }
}
