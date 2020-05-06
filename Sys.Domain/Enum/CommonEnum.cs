using System;
using System.Collections.Generic;
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
        Role = 0,
        User = 1
    }
    public enum AccessEnum
    { 
        Menu,
        Module,
        Operate,
    }
    public enum HttpStatusCodeEnum
    {
        成功 = 200,
        令牌无效 = 0,
        令牌过期 = 1,
        无权限 = 2,
        程序异常 = 3,
        系统异常 = 4
    }
}
