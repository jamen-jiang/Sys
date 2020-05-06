using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class ModuleNode
    {
        public ModuleNode()
        {
            this.Children = new List<ModuleNode>();
        }
        public static ModuleNode ModuleToNode(Module module)
        {
            ModuleNode node = new ModuleNode();
            node.Id = module.Id;
            node.Name = module.Name;
            node.Icon = module.Icon;
            node.Sort = module.Sort;
            node.Remark = module.Remark;
            node.IsEnable = module.IsEnable;
            return node;
        }
        public static ModuleNode MenuToNode(Menu menu)
        {
            ModuleNode node = new ModuleNode();
            node.Id = menu.Id;
            node.ModuleId = menu.ModuleId;
            node.PId = menu.PId;
            node.Type = Utils.GetEnumName<MenuTypeEnum>(menu.Type.ToString(), false);
            node.Name = menu.Name;
            node.Remark = menu.Remark;
            node.Icon = menu.Icon;
            node.Sort = menu.Sort;
            node.VueUri = menu.VueUri;
            node.IsEnable = menu.IsEnable;
            return node;
        }
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int PId { get; set; }
        /// <summary>
        /// 模块类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        public string VueUri { get; set; }
        public bool IsEnable { get; set; }
        public List<VMOperate> Operates { get; set; }
        public List<ModuleNode> Children { get; set; }
    }
}
