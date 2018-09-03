using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Helper
{
    internal class ObjectToUriParam
    {
        /// <summary>
        /// 对象编码为请求字符串
        /// </summary>
        /// <param name="obj">待编码对象</param>
        /// <param name="url">请求URL</param>
        /// <param name="isAddParaMark">是否？</param>
        /// <param name="removeItems">要移除对象中的公共对象</param>
        /// <returns></returns>
        internal static string Encode(object obj, string url = "", bool isAddParaMark = false, params string[] removeItems)
        {
            if (!string.IsNullOrEmpty(url))
            {
                isAddParaMark = true;
            }
            List<PropertyInfo> propertis = obj.GetType().GetProperties().ToList();
            if (removeItems.Length > 0)
            {
                List<PropertyInfo> removeList = new List<PropertyInfo>();
                foreach (var item in removeItems)
                {
                    foreach (var property in propertis)
                    {
                        if (property.Name == item)
                        {
                            removeList.Add(property);
                        }
                    }
                }
                if (removeList.Count > 0)
                {
                    foreach (var item in removeList)
                    {
                        propertis.Remove(item);
                    }
                }
            }

            propertis = propertis.OrderBy(p => p.Name).ToList();   //对参数进行升序排序

            StringBuilder sb = new StringBuilder();
            sb.Append(url);
            if (isAddParaMark)
            {
                sb.Append("?");
            }
            foreach (var p in propertis)
            {
                var v = p.GetValue(obj, null);
                if (v == null)
                {
                    continue;
                }

                sb.Append(p.Name);
                sb.Append("=");
                sb.Append(WebUtility.UrlEncode(v.ToString()));
                sb.Append("&");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        internal static object Decode(string url)
        {
            return null;
        }
    }
}
