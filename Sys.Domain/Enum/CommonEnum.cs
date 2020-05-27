using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public enum OperateTypeEnum
    {
        按钮 = 0,
        普通请求 = 1
    }
    public enum MenuTypeEnum
    { 
        目录 = 0,
        菜单 = 1,
    }
    public enum ApiTypeEnum
    { 
        公共 = 0
    }
    public enum MasterEnum
    { 
        [Description("角色")]
        Role = 0,
        [Description("用户")]
        User = 1
    }
    public enum AccessEnum
    {
        [Description("菜单")]
        Menu,
        [Description("模块")]
        Module,
        [Description("操作")]
        Operate,
    }
    public enum ApiStatusEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 200,
        /// <summary>
        /// 令牌无效
        /// </summary>
        [Description("令牌无效")]
        FAIL_TOKEN_UNVALID = 1,
        /// <summary>
        /// 令牌过期
        /// </summary>
        [Description("令牌过期")]
        EXPIRED_TOKEN_UNVALID = 2,
        /// <summary>
        /// 没访问权限
        /// </summary>
        [Description("没访问权限")]
        FAIL_PERMISSION = 3,
        /// <summary>
        /// 应用程序错误
        /// </summary>
        [Description("应用程序错误")]
        FAIL_APP = 98,
        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        FAIL_EXCEPTION = 99,
        /// <summary>
        /// 403
        /// </summary>
        [Description("403")]
        FAIL_CODE = 403
    }
}
