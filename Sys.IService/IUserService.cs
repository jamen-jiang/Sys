using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.IService
{
    public partial interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseLogin Login(RequestLogin request);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        ResponseGetUserList GetUserList(HttpApiRequest request);
        /// <summary>
        /// 根据Id获取User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResponseGetUser GetUser(RequestGetUser request);
    }
}
