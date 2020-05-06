using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class VMUser
    {
        public static VMUser ToPoCo(User user)
        {
            VMUser model = new VMUser();
            model.Id = user.Id;
            model.UserName = user.UserName;
            model.Name = user.Name;
            model.Remark = user.Remark;
            model.IsEnable = user.IsEnable;
            model.CreatedBy = user.CreatedBy;
            model.CreatedOn = user.CreatedOn;
            model.UpdatedBy = user.UpdatedBy;
            model.UpdatedOn = user.UpdatedOn;
            return model;
        }
        public static IEnumerable<VMUser> ToListPoCo(IEnumerable<User> list)
        {
            var listModel = new List<VMUser>();
            foreach (User item in list)
            {
                listModel.Add(VMUser.ToPoCo(item));
            }
            return listModel;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool IsEnable { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        
    }
}
