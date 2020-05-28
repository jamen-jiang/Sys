using Sys.Common;
using Sys.Domain;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class ModuleService : BaseService, IModuleService
    {
        /// <summary>
        /// 获取模块树
        /// </summary>
        /// <returns></returns>
        public ApiResponse GetModuleTree()
        {
            using (var db = base.NewDB())
            {
                List<Module> modules = db.Module.ToList();
                List<Menu> menus = db.Menu.ToList();
                List<Operate> operates = db.Operate.ToList();
                List<VMOperate> vMOperates = VMOperate.ToListPoCo(operates).ToList();
                List<ModuleNode> tree = new List<ModuleNode>();
                foreach (Module m in modules)
                {
                    ModuleNode node = ModuleNode.ModuleToNode(m);
                    CreateModuleTree(node, menus, m.Id, vMOperates,false);
                    tree.Add(node);
                }
                ApiResponse response = new ApiResponse(Request, tree);
                return response;
            }
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        public void AddModule()
        {
            using (var db = base.NewDB())
            {
                RequestEditModule obj = ConvertToModel<RequestEditModule>();
                if (db.Module.IsExist(obj.Name))
                    throw new ApplicationException("模块名称已存在!");
                Module module = new Module();
                module.Name = obj.Name;
                module.IsEnable = true;
                module.Remark = obj.Remark;
                module.Sort = obj.Sort;
                module.Icon = obj.Icon;
                module.CreatedBy = obj.UserId;
                module.CreatedOn = DateTime.Now;
                db.Module.Add(module);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 修改模块
        /// </summary>
        public void EditModule()
        {
            using (var db = base.NewDB())
            {
                RequestEditModule obj = ConvertToModel<RequestEditModule>();
                if (db.Module.IsExist(obj.Name, obj.Id))
                    throw new ApplicationException("模块名称已存在!");
                Module module = new Module();
                module.Id = obj.Id;
                module.Name = obj.Name;
                module.IsEnable = obj.IsEnable;
                module.Remark = obj.Remark;
                module.Sort = obj.Sort;
                module.Icon = obj.Icon;
                module.UpdatedBy = obj.UserId;
                module.UpdatedOn = DateTime.Now;
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        private void CreateModuleTree(ModuleNode node, List<Menu> menus, int parentId, List<VMOperate> operates,bool isMenu = true)
        {
            List<Menu> childs = new List<Menu>();
            if(isMenu)
                childs = menus.Where(x => x.PId == parentId).ToList();
            else
                childs = menus.Where(x => x.ModuleId == parentId && x.PId == 0).ToList();
            foreach (var c in childs)
            {
                ModuleNode n = ModuleNode.MenuToNode(c);
                if(c.Type == (int)MenuTypeEnum.菜单)
                    n.Operates = operates.Where(x => x.MenuId == n.Id).ToList();
                node.Children.Add(n);
                CreateModuleTree(n, menus, c.Id, operates);
            }
        }
    }
}
