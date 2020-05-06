using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public static class OperateExtensions
    {
        /// <summary>
        /// 根据operateIds获取Operate的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="operateIds"></param>
        /// <returns></returns>
        public static IQueryable<Operate> WhereByOperateIds(this IQueryable<Operate> query, params int[] operateIds)
        {
            if (operateIds != null)
            {
                query = query.Where(x => operateIds.Contains(x.Id));
            }
            return query;
        }
    }
}
