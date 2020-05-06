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
    public class RoleService : BaseService, IRoleService
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        //public List<Role> GetRoleList(List<int> roleIdList)
        //{
        //    return ApiRep.GetRoleList(roleIdList);
        //}
    }
}
