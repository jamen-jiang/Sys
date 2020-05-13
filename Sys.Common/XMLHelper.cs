using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sys.Common
{
    public static class XMLHelper
    {
        /// <summary>
        /// 从XML字符串中反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeSerializerString<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// 读入一个文件，并按XML的方式反序列化对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeSerializeXML<T>(string filePath) where T : class
        {
            T local = default(T);
            if (File.Exists(filePath))
            {
                XmlSerializer serializer;
                FileStream stream = null;
                try
                {
                    stream = new FileStream(filePath, FileMode.Open);
                    serializer = new XmlSerializer(typeof(T));
                    local = (T)serializer.Deserialize(stream);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    serializer = null;
                }
            }
            return local;
        }
        /// <summary>
        /// 将一个对象序列化为XML字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="isClearFlag"></param>
        /// <returns></returns>
        public static string SerializerString<T>(T obj, bool isClearFlag)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                string str = writer.ToString();
                if (isClearFlag)
                {
                    str = str.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                }
                return str;
            }
        }
        public static void SerializeXML<T>(T obj, string filePath)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(filePath, FileMode.OpenOrCreate);
                stream.SetLength(0L);
                new XmlSerializer(typeof(T)).Serialize((Stream)stream, obj);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

    }
}
