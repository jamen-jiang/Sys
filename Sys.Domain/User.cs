//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sys.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Role_User = new HashSet<Role_User>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool IsEnable { get; set; }
        public bool IsDel { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role_User> Role_User { get; set; }
    }
}
