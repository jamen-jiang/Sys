using Sys.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class VMOperate
    {

        public static VMOperate ToPoCo(Operate operate)
        {
            VMOperate model = new VMOperate();
            model.Id = operate.Id;
            model.MenuId = operate.MenuId;
            model.ApiId = operate.ApiId;
            model.Type = Utils.GetEnumName<OperateTypeEnum>(operate.Type.ToString(),false);
            model.Code = operate.Code;
            model.Name = operate.Name;
            model.Icon = operate.Icon;
            model.Sort = operate.Sort;
            model.Remark = operate.Remark;
            model.IsPublic = operate.IsPublic;
            model.IsEnable = operate.IsEnable;
            model.CreatedBy = operate.CreatedBy;
            model.CreatedOn = operate.CreatedOn;
            model.UpdatedBy = operate.UpdatedBy;
            model.UpdatedOn = operate.UpdatedOn;
            return model;
        }
        public static IEnumerable<VMOperate> ToListPoCo(IEnumerable<Operate> list)
        {
            var listModel = new List<VMOperate>();
            foreach (Operate item in list)
            {
                listModel.Add(VMOperate.ToPoCo(item));
            }
            return listModel;
        }
        public int Id { get; set; }
        public Nullable<int> MenuId { get; set; }
        public Nullable<int> ApiId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Remark { get; set; }
        public bool IsPublic { get; set; }
        public bool IsEnable { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
