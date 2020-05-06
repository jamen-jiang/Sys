using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sys.Common
{
    public static class HttpSession
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void Set(string name, object value)
        {
            HttpContext.Current.Session[name] = value;
        }
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object Get(string name)
        {
            return HttpContext.Current.Session[name];
        }
        /// <summary>
        /// 移除Session
        /// </summary>
        /// <param name="name"></param>
        public static void Remove(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }
    }
}
