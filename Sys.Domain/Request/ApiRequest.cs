using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class ApiRequest
    {
        public string Code { get; set; }
        public string Token { get; set; }
        public string Version { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public dynamic Params { get; set; }
        public ApiWorkContext ApiWorkContext { get; set; }
    }
    /// <summary>
    /// API上下文信息
    /// </summary>
    public class ApiWorkContext
    {
        public int UserId { get; set; }
    }
}
