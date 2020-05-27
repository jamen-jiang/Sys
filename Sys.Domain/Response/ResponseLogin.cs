using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class PermissionTree
    {
        public PermissionTree()
        {
            ModuleList = new List<ModuleTree>();
            MenuList = new List<MenuTree>();
            OperateList = new List<OperateTree>();
        }
        public List<ModuleTree> ModuleList { get; set; }
        public List<MenuTree> MenuList { get; set; }
        public List<OperateTree> OperateList { get; set; }
    }

    public class ModuleTree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
    }
    public class MenuTree
    {
        public MenuTree()
        {
            Children = new List<MenuTree>();
        }
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public string VueUri { get; set; }
        public List<OperateTree> OperateTreeList { get; set; }
        public List<MenuTree> Children { get; set; }
    }
    public class OperateTree
    {
        public Nullable<int> MenuId { get; set; }
        public int Type { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
    }
    public class ResponseLogin
    {
        public string Token { get; set; }
        public PermissionTree Permission { get; set; }
    }
}
