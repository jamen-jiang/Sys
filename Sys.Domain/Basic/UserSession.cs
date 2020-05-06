using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Module> ModuleList { get; set; }
        //public List<Menu> MenuList { get; set; }
        //public List<Operate> OperateList { get; set; }
        public List<ApiRoute> ApiRouteList { get; set; }
    }

}
