using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
