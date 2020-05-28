using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sys.Domain
{
    /// <summary>
    /// 判断是否需要Token(登录)
    /// </summary>
    public class ApiNotNeedTokenAttribute : Attribute
    {
        public ApiNotNeedTokenAttribute()
        {
            NotNeedToken = true;
        }

        public ApiNotNeedTokenAttribute(bool notNeedToken)
        {
            NotNeedToken = notNeedToken;
        }
        public bool NotNeedToken { get; set; }
    }
}