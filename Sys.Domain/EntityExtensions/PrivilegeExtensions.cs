using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public static class PrivilegeExtensions
    {
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <param name="accessValues">领域对象Id</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access, int [] masterValues, params int []  accessValues)
        {
            if (master != null)
                query = query.Where(w => w.Master == master.ToString());
            if (masterValues != null)
                query = query.Where(w => masterValues.Contains(w.MasterValue));
            if (access != null)
                query = query.Where(w => w.Access == access.ToString());
            if (accessValues != null)
                query = query.Where(w => accessValues.Contains(w.AccessValue));
            return query.Distinct();
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access, params int [] masterValues)
        {
            return Get(query, master, access, masterValues, null);
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master, AccessEnum? access)
        {
            return Get(query, master, access, null, null);
        }
        /// <summary>
        /// 获取Privilege的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <returns></returns>
        public static IQueryable<Privilege> Get(this IQueryable<Privilege> query, MasterEnum? master)
        {
            return Get(query, master, null, null, null);
        }
        /// <summary>
        /// 获取AccessValue的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="access">领域对象(菜单或者按钮)</param>
        /// <param name="masterValues">主体对象Id</param>
        /// <returns></returns>
        public static List<int> GetAccessValueList(this IQueryable<Privilege> query, MasterEnum master, AccessEnum sccess, params int [] masterValues)
        {
            return Get(query, master, sccess, masterValues).Select(s => s.AccessValue).ToList();
        }
        /// <summary>
        /// 获取AccessValue的列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="master">主体对象类型(角色或者用户)</param>
        /// <param name="masterValue">主体对象Id</param>
        /// <returns></returns>
        public static List<Privilege> GetPrivilegeList(this IQueryable<Privilege> query, MasterEnum ? master, params int[] masterValues)
        {
            return Get(query, master, null, masterValues).Distinct().ToList();
        }
    }
}
