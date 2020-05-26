using Sys.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    /// <summary>
    /// 返回Model
    /// </summary>
    public class ApiResponse
    {
        private ApiRequest Request { get; set; }

        public ApiResponse()
        {
            Status = (int)ApiStatusEnum.SUCCESS;
        }
        public ApiResponse(ApiRequest request)
        {
            Request = request;
            Status = (int)ApiStatusEnum.SUCCESS;
        }
        public ApiResponse(ApiRequest request, dynamic data)
        {
            Request = request;
            Data = data;
            Status = (int)ApiStatusEnum.SUCCESS;
        }

        public ApiResponse(ApiRequest request, ApiStatusEnum apiStatusEnum, string message = "")
        {
            Request = request;
            Status = (int)apiStatusEnum;
            Message = message;
        }

        public ApiResponse(ApiRequest request, int apiStatusEnum, string message = "")
        {
            Request = request;
            Status = apiStatusEnum;
            Message = message;
        }

        private string code;
        public string Code
        {
            get
            {
                if (string.IsNullOrEmpty(code))
                {
                    if (Request == null || string.IsNullOrEmpty(Request.Code))
                    {
                        return "";
                    }
                    return Request.Code;
                }
                return code;

            }
            set
            {
                code = value;
            }
        }
        public int Status { get; set; }
        private string message;
        public string Message
        {
            get
            {
                return string.IsNullOrEmpty(message) 
                    ? Utils.GetEnumName<ApiStatusEnum>(Status.ToString()) 
                    : message;
            }
            set
            {
                message = value;
            }
        }
        public int TotalCount{get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public dynamic Data { get; set; }
    }
}
