using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    /// <summary>
    /// 公共接口
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        ApiResponse Login();
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        ApiResponse Layout();
    }

}
