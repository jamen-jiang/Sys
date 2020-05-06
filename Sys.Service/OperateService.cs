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
    public class OperateService : BaseService, IOperateService
    {
        /// <summary>
        /// 获取ApiId列表
        /// </summary>
        /// <param name="operateIdList"></param>
        /// <returns></returns>
        //public List<int> GetApiIdList(List<int> operateIdList)
        //{
        //    List<Operate> list = OperateRep.GetOperateList(operateIdList);
        //    return list.Where(w => w.ApiId != null).Select(s => s.ApiId.Value).ToList();
        //}
    }
}
