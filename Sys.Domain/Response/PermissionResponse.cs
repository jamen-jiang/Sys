using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class PermissionResponse
    {
        public List<ModuleResponse> ModuleList { get; set; }
    }
    public class ModuleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        List<MenuResponse> MenuList { get; set; }
    }
    public class MenuResponse
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public string VueUri { get; set; }
        public List<OperateResponse> OperateList { get; set; }
    }
    public class OperateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }

    }
}
