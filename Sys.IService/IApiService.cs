using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IApiService
    {
        /// <summary>
        /// 获取ApiRoute列表
        /// </summary>
        /// <returns></returns>
        List<ApiRoute> GetApiRouteList();
    }
}
