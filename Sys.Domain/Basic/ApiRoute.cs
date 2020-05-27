using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    [Serializable]
    public class ApiRoute
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string ServiceName { get; set; }
    }
}
