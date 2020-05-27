using Sys.Common;
using Sys.Domain;
using Sys.IService;
using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public partial class UserService : BaseService, IUserService
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ResponseGetUserList GetUserList(HttpApiRequest request)
        {
            using (var db = base.NewDB())
            {
                List<User> list = db.User.ToList();
                List<VMUser> vmUserList = VMUser.ToListPoCo(list).ToList();
                ResponseGetUserList response = new ResponseGetUserList();
                response.UserList = vmUserList;
                return response;
            }
        }
        /// <summary>
        /// 根据Id获取User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseGetUser GetUser(RequestGetUser request)
        {
            using (var db = base.NewDB())
            {
                User user = db.User.Find(request.Id);
                VMUser model = VMUser.ToPoCo(user);
                ResponseGetUser response = new ResponseGetUser();
                response.User = model;
                return response;
            }
        }
        public void CreateMenuTree(MenuTree tree, List<Menu> list, int parentId, List<Operate> oplist)
        {
            var childList = list.Where(x => x.PId == parentId).ToList();
            foreach (var c in childList)
            {
                MenuTree t = new MenuTree()
                {
                    Id = c.Id,
                    PId = c.PId,
                    ModuleId = c.ModuleId,
                    Name = c.Name,
                    Icon = c.Icon,
                    Type = c.Type,
                    VueUri = c.VueUri,
                    Sort = c.Sort,
                    Remark = c.Remark,
                    //OperateTreeList = oplist.Where(x => x.MenuId == c.Id).Select(s => new OperateTree()
                    //{
                    //    MenuId = s.MenuId,
                    //    Code = s.Code,
                    //    Icon = s.Icon,
                    //    Type = s.Type
                    //}).ToList()
                };
                tree.Children.Add(t);
                CreateMenuTree(t, list, t.Id, oplist); 
            }
        }
    }
}
