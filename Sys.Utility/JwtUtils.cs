using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Utility
{
    public enum JwtStatusEnum
    {
        [Description("成功")]
        Success = 0,
        [Description("Token失效")]
        TokenExpired = 1,
        [Description("其他")]
        Other = 2
    }
    public class JwtUtils
    {
        //私钥  web.config中配置
        //"GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        private static string secret = ConfigurationManager.AppSettings["Secret"].ToString();
        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string SetJwtEncode<T>(T model)
        {
            System.Reflection.PropertyInfo[] obj = model.GetType().GetProperties();
            Dictionary<string, object> payload = new Dictionary<string, object>();
            foreach (var o in obj)
            {
                payload.Add(o.Name, o.GetValue(model));
            }
            //格式如下
            //var payload = new Dictionary<string, object>
            //{
            //    { "username","admin" },
            //    { "pwd", "claim2-value" }
            //};

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }
        /// <summary>
        /// 根据jwtToken  获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        public static bool TryGetJwtDecode<T>(string token,out T payload)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, jwtAlgorithm);
                payload = decoder.DecodeToObject<T>(token, secret, verify: true);//token为之前生成的字符串
                return true;
            }
            catch (TokenExpiredException)
            {
                payload = default(T);
                return false;
            }
            //catch (SignatureVerificationException ex)
            //{
            //    Console.WriteLine("Token has invalid signature");
            //    throw new Exception(ex.Message);
            //}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
