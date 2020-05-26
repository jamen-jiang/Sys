using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
   public  class RequestEditModule:HttpApiRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public bool IsEnable { get; set; }
    }
}
