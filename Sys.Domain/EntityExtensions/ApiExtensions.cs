using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public static class ApiExtensions
    {
        /// <summary>
        /// 获取Api的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isPublic">是否公用</param>
        /// <param name="operateIds">操作Id列表</param>
        /// <returns></returns>
        public static IQueryable<Api> Get(this IQueryable<Api> query, bool ? isPublic, params int [] operateIds)
        {
            query = from a in query
                    from b in a.Operate
                    where  b.IsEnable == true && a.IsEnable == true
                    select a;
            
            if (operateIds != null)
            {
                query = from a in query
                        from b in a.Operate
                        where operateIds.Contains(b.Id)
                        select a;
            }
            if (isPublic != null)
            {
                query = from a in query
                        from b in a.Operate
                        where b.IsPublic == isPublic.Value
                        select a;
            }
            return query;
        }
        /// <summary>
        /// 获取Api的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isPublic">是否公用</param>
        /// <returns></returns>
        public static IQueryable<Api> Get(this IQueryable<Api> query, bool ? isPublic)
        {
            query = Get(query, isPublic,null);
            return query;
        }
        /// <summary>
        /// 获取Api的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isPublic">是否公用</param>
        /// <returns></returns>
        public static IQueryable<Api> Get(this IQueryable<Api> query)
        {
            query = Get(query, null, null);
            return query;
        }
        /// <summary>
        /// 根据operateIdList获取ApiRoute的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isPublic">是否公用</param>
        /// <param name="operateIds">操作Id列表</param>
        /// <returns></returns>
        public static List<ApiRoute> GetApiRouteList(this IQueryable<Api> query, bool ? isPublic = false, params int [] operateIds)
        {
            query = Get(query, isPublic, operateIds);
            var obj = from a in query
                      from b in a.Operate
                      select new ApiRoute
                      {
                          Code = b.Code,
                          Name = b.Name,
                          IsPublic = b.IsPublic,
                          AssemblyName = a.AssemblyName,
                          ClassName = a.ClassName,
                          MethodName = a.MethodName
                      };
            return obj.ToList();
        }
    }
}
