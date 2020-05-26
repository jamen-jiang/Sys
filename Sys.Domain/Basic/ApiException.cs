using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    public class ApiException : ApplicationException
    {
        private int _code;
        /// <summary>
        /// 错误代码
        /// </summary>
        public int Code
        {
            get
            {
                return _code == 0 ? (int)ApiStatusEnum.FAIL_APP : _code;
            }
            set
            {
                _code = value;
            }
        }

        private string _message { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public override string Message
        {
            get
            {
                return string.IsNullOrEmpty(_message) ? base.Message : _message;
            }
        }
        /// <summary>
        /// 默认错误信息
        /// </summary>
        public ApiException() { }

        /// <summary>
        /// 错误代码
        /// </summary>
        /// <param name="code">代码</param>
        public ApiException(int code)
        {
            Code = code;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message">错误信息</param>
        public ApiException(string message)
        {
            _message = message;
        }
        /// <summary>
        /// 代码和信息
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="message">错误信息</param>
        public ApiException(int code, string message)
        {
            Code = code;
            _message = message;
        }
    }
}
