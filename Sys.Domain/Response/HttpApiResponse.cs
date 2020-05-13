using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class HttpApiResponse
    {
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 对应状态的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 状态Code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public object Data { get; set; }
        public HttpApiResponse()
        {
            this.IsSuccess = true;
            this.StatusCode = (int)StatusCodeEnum.SUCCESS;
        }
        public HttpApiResponse(int errorCode)
        {
            this.IsSuccess = false;
            this.StatusCode = errorCode;
        }
    }
    public enum StatusCodeEnum
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
        FAIL_TOKEN_UNVALID = 0,
        /// <summary>
        /// 令牌过期
        /// </summary>
        [Description("令牌过期")]
        EXPIRED_TOKEN_UNVALID = 1,
        /// <summary>
        /// 没访问权限
        /// </summary>
        [Description("没访问权限")]
        FAIL_PERMISSION = 2,
        /// <summary>
        /// 应用程序错误
        /// </summary>
        [Description("应用程序错误")]
        FAIL_APP = 3,
        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        FAIL_EXCEPTION = 4,
        /// <summary>
        /// 403
        /// </summary>
        [Description("403")]
        FAIL_CODE = 403
    }
}
