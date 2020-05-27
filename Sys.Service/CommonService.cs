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
    public class CommonService : BaseService, ICommonService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [ApiNotNeedToken]
        public ApiResponse Login()
        {
            using (var db = base.NewDB())
            {
                RequestLogin obj = ConvertToModel<RequestLogin>();
                User user = db.User.FirstOrDefault(x => x.UserName == obj.UserName && x.PassWord == obj.PassWord);
                if (user == null)
                    throw new ApiException("用户名或密码错误!");
                TokenSession ts = new TokenSession(user.Id);
                Payload payload = new Payload(ts);
                string token = JwtUtils.SetJwtEncode(payload);
                ApiResponse response = new ApiResponse(Request, token);
                return response;
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ApiResponse Layout()
        {
            using (var db = base.NewDB())
            {
                List<Module> moduleList = null;
                List<Menu> menuList = null;
                List<Operate> operateList = null;
                //如果是管理员
                if (WorkContext.UserId == 1)
                {
                    //取出所有模块
                    moduleList = db.Module.WhereByModuleIds(null).ToList();
                    menuList = db.Menu.WhereByMenuIds(null).ToList();
                    operateList = db.Operate.WhereByOperateIds(null).ToList();
                }
                else
                {
                    int[] roleIdList = db.Role.GetRoleIdList(WorkContext.UserId).ToArray();
                    List<Privilege> privilegeList = db.Privilege.Get(MasterEnum.Role, null, roleIdList).ToList();
                    int[] moduleIds = privilegeList.Where(x => x.Access == AccessEnum.Module.ToString()).Select(s => s.AccessValue).ToArray();
                    int[] menuIds = privilegeList.Where(x => x.Access == AccessEnum.Menu.ToString()).Select(s => s.AccessValue).ToArray();
                    int[] operateIds = privilegeList.Where(x => x.Access == AccessEnum.Operate.ToString()).Select(s => s.AccessValue).ToArray();
                    moduleList = db.Module.WhereByModuleIds(moduleIds).ToList();
                    menuList = db.Menu.WhereByMenuIds(menuIds).ToList();
                    operateList = db.Operate.WhereByOperateIds(operateIds).ToList();
                }
                PermissionTree tree = new PermissionTree();
                tree.OperateList = operateList.Select(s => new OperateTree()
                {
                    MenuId = s.MenuId,
                    Code = s.Code,
                    Icon = s.Icon,
                    Type = s.Type
                }).ToList();
                tree.ModuleList = moduleList.Select(s => new ModuleTree
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
                        tree.MenuList.Add(mtree);
                    }
                }
                ApiResponse response = new ApiResponse(Request, tree);
                return response;
            }
        }

        private void CreateMenuTree(MenuTree tree, List<Menu> list, int parentId, List<Operate> oplist)
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
