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
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseLogin Login(RequestLogin request)
        {
            using (var db = base.NewDB())
            {
                User user = db.User.FirstOrDefault(x => x.UserName == request.UserName && x.PassWord == request.PassWord);
                if (user != null)
                {
                    UserSession model = new UserSession();
                    model.Id = user.Id;
                    model.Name = user.Name;
                    List<ApiRoute> apiList = null;
                    List<Module> moduleList = null;
                    List<Menu> menuList = null;
                    List<Operate> operateList = null;
                    //如果是管理员
                    if (user.Id == 1)
                    {
                        //取出全部api列表
                        apiList = db.Api.GetApiRouteList(false, null);
                        moduleList = db.Module.WhereByModuleIds(null).ToList();
                        menuList = db.Menu.WhereByMenuIds(null).ToList();
                        operateList = db.Operate.WhereByOperateIds(null).ToList();
                    }
                    else
                    {
                        int[] roleIdList = db.Role.GetRoleIdList(user.Id).ToArray();
                        //获取roleIdList的所有操作Id列表
                        int[] accessIdList = db.Privilege.GetAccessValueList(MasterEnum.Role, AccessEnum.Operate, roleIdList).ToArray();
                        //获取有权限的api列表
                        apiList = db.Api.GetApiRouteList(true, accessIdList);
                        List<Privilege> privilegeList = db.Privilege.Get(MasterEnum.Role, null, roleIdList).ToList();
                        int[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                        int[] menuIds = privilegeList.Where(x => x.Access == AccessEnum.Menu.ToString()).Select(s => s.AccessValue).ToArray();
                        int[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Menu.ToString()).Select(s => s.AccessValue).ToArray();
                        moduleList = db.Module.WhereByModuleIds(moduleIds).ToList();
                        menuList = db.Menu.WhereByMenuIds(menuIds).ToList();
                        operateList = db.Operate.WhereByOperateIds(operateIds).ToList();
                    }
                    PermissionTree tree = new PermissionTree();
                    tree.OperateTreeList = operateList.Select(s => new OperateTree()
                    {
                        MenuId = s.MenuId,
                        Code = s.Code,
                        Icon = s.Icon,
                        Type = s.Type
                    }).ToList();
                    tree.ModuleTreeList = moduleList.Select(s => new ModuleTree
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Icon = s.Icon,
                        Remark = s.Remark,
                        Sort = s.Sort
                    }).ToList();

                    foreach (var module in moduleList)
                    {
                        List<Menu> mList = menuList.Where(x => x.ModuleId == module.Id).ToList();
                        var pList = mList.Where(x => x.PId == 0).ToList();
                        foreach (var p in pList)
                        {
                            MenuTree mtree = new MenuTree() 
                            {
                                Id = p.Id,
                                PId = p.PId,
                                ModuleId = p.ModuleId,
                                Name = p.Name,
                                Icon = p.Icon,
                                Type = p.Type,
                                VueUri = p.VueUri,
                                Sort = p.Sort,
                                Remark = p.Remark,
                            };
                            CreateMenuTree(mtree, mList, p.Id, operateList);
                            tree.MenuTreeList.Add(mtree);
                        }
                    }
                    TokenSession ts = new TokenSession(user.Id, apiList);
                    Payload payload = new Payload(ts);
                    string token = JwtUtils.SetJwtEncode(payload);
                    ResponseLogin response = new ResponseLogin();
                    response.Token = token;
                    response.Permission = tree;
                    return response;
                }
                throw new ApplicationException("用户名或密码错误!");
            }
        }
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
