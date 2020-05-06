using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public static class UserExtensions
    {
        /// <summary>
        /// 根据用户Id获取Role的IQueryable
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public static IQueryable<User> WhereByUserId(this IQueryable<User> query, int userId)
        //{
        //    var obj = from a in query
        //              from b in a.user
        //              where b.UserId == userId
        //              select a;
        //    return obj.Distinct();
        //}
        /// <summary>
        /// 根据用户Id获取RoleId列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public static List<int> GetRoleIdList(this IQueryable<Role> query, int userId)
        //{
        //    return WhereByUserId(query, userId).Select(s => s.Id).ToList();
        //}
    }
}
