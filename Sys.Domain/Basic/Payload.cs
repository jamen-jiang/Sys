using Sys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Domain
{
    public class Payload
    {
        public Payload(object data,int minutes = 60)
        {
            DateTime now = DateTime.Now;
            this.iat = Helper.DateTime2TimeStamp(now);
            this.exp = Helper.DateTime2TimeStamp(now.AddMinutes(minutes));
            this.data = data;
        }
        /// <summary>
        /// 非必须。issuer 请求实体，可以是发起请求的用户的信息，也可是jwt的签发者。
        /// </summary>
        public string iss { get; set; }
        /// <summary>
        /// 非必须。issued at。 token创建时间，unix时间戳格式
        /// </summary>
        public string iat { get; set; }
        /// <summary>
        /// 非必须。expire 指定token的生命周期。unix时间戳格式
        /// </summary>
        public string exp { get; set; }
        /// <summary>
        /// 非必须。接收该JWT的一方。
        /// </summary>
        public string aud { get; set; }
        /// <summary>
        /// 非必须。该JWT所面向的用户
        /// </summary>
        public string sub { get; set; }
        /// <summary>
        /// 非必须。not before。如果当前时间在nbf里的时间之前，则Token不被接受；一般都会留一些余地，比如几分钟。
        /// </summary>
        //public string nbf { get; set; }
        /// <summary>
        /// 非必须。JWT ID。针对当前token的唯一标识
        /// </summary>
        public string jti { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }
    }
}
