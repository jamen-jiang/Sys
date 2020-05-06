using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class RequestEditMenu : HttpApiRequest
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int PId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public string VueUri { get; set; }
        public bool IsEnable { get; set; }
    }
}