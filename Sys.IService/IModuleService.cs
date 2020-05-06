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
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseGetModuleTree GetModuleTree(HttpApiRequest request);
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="request"></param>
        void AddModule(RequestEditModule request);
    }
}
