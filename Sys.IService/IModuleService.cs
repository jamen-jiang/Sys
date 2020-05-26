using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public interface IModuleService
    {
        /// <summary>
        /// 获取模块树
        /// </summary>
        /// <returns></returns>
        ApiResponse GetModuleTree();
        /// <summary>
        /// 添加模块
        /// </summary>
        void AddModule();
    }
}
