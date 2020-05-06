using Sys.Common;
using Sys.Domain;
using Sys.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public class MenuService : BaseService, IMenuService
    {
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="request"></param>
        public void AddMenu(RequestEditModule request)
        {
            using (var db = base.NewDB())
            {
                if (db.Module.IsExist(request.Name))
                    throw new ApplicationException("模块名称已存在!");
                Module module = new Module();
                module.Name = request.Name;
                module.IsEnable = true;
                module.Remark = request.Remark;
                module.Sort = request.Sort;
                module.Icon = request.Icon;
                module.CreatedBy = request.UserId;
                module.CreatedOn = DateTime.Now;
                db.Module.Add(module);
                db.SaveChanges();
            }
        }
    }
}
