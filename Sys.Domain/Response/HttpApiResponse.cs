using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            this.StatusCode = HttpStatusCode.SUCCESS;
        }
    }
    /// <summary>
    /// 状态
    /// </summary>
    public struct HttpStatusCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static int SUCCESS = 200;
        /// <summary>
        /// 令牌无效
        /// </summary>
        public static int FAIL_TOKEN_UNVALID = 0;
        /// <summary>
        /// 令牌过期
        /// </summary>
        public static int EXPIRED_TOKEN_UNVALID = 1;
        /// <summary>
        /// 没权限访问
        /// </summary>
        public static int FAIL_PERMISSION  = 2;
        /// <summary>
        /// 应用程序错误
        /// </summary>
        public static int FAIL_APP = 3;
        /// <summary>
        /// 系统异常
        /// </summary>
        public static int FAIL_EXCEPTION = 4;
        /// <summary>
        /// 403
        /// </summary>
        public static int FAIL_CODE = 403;
    }
    public enum StatusCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [JsonProperty("1000")]
        Success = 1000,

        /// <summary>
        /// 登录超时,需重新登录
        /// </summary>
        [JsonProperty("2000")]
        NeedLogin = 2000,

        /// <summary>
        /// 程序异常
        /// </summary>
        [JsonProperty("3000")]
        Exception = 3000,

        /// <summary>
        /// 系统错误
        /// </summary>
        [JsonProperty("4000")]
        SysError = 4000
    }
}
