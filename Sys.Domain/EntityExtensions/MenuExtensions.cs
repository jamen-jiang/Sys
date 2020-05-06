using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public static class MenuExtensions
    {
        /// <summary>
        /// 根据menuIds获取Module的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public static IQueryable<Menu> WhereByMenuIds(this IQueryable<Menu> query, params int [] menuIds)
        {
            if(menuIds != null)
            {
                query = query.Where(x => menuIds.Contains(x.Id));
            }
            return query;
        }
    }
}
