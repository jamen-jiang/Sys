using Sys.Common;
using Sys.Domain;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class ApiService : BaseService, IApiService
    {
        /// <summary>
        /// 获取ApiRoute列表
        /// </summary>
        /// <returns></returns>
        public List<ApiRoute> GetApiRouteList()
        {
            using (var db = base.NewDB())
            {
                return db.Api.GetApiRouteList(null,null); 
            }
        }
    }
}
