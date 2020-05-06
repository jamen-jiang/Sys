using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    /// <summary>
    /// 执行接口的方法获取返回值
    /// </summary>
    public interface ICmdService
    {
        object Execute(ApiRoute api, Dictionary<string, object> dict);
    }
}
