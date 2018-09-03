using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using AliyunDnsSDK.Helper;
using AliyunDnsSDK.Logger;

namespace AliyunDnsSDK
{
    public class AliyunDnsApi
    {
        public AliyunDnsApi()
        {
            Config config = new Config();
        }

        public T Request<T>(object obj, bool isSaveLog = false) where T : class
        {
            HttpHelper httpHelper = new HttpHelper();

            string requestUrl = CreateUrl(obj);
            try
            {
                string result = httpHelper.HttpGet(requestUrl);
                if (string.IsNullOrEmpty(result))
                {
                    if (isSaveLog)
                    {
                        Log.Write("请求失败，返回的数据为空！", requestUrl, LogType.Error, MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                    }
                    return null;
                }
                else
                {
                    if (isSaveLog)
                    {
                        Log.Write("请求成功！", requestUrl, LogType.Error, MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                    }
                    return JsonHelper.DeserializeJsonToObject<T>(result);
                }
            }
            catch (Exception ex)
            {
                if (isSaveLog)
                {
                    Log.Write($"{ex.Message}", requestUrl, LogType.Error, MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public string CreateUrl(object obj)
        {
            //设置公共参数默认值
            SetPublicParametersValue(obj);
            //创建Signature
            string noSignUrl = ObjectToUriParam.Encode(obj, "", false, "Signature");
            string sign = Encrypt.ToBase64hmac(BuildRequestPara(noSignUrl), Config.AccessKeySecret + "&");
            //创建Signature Dictionary
            Dictionary<string, string> signDic = new Dictionary<string, string>();
            signDic.Add("Signature", sign);
            //设置obj Signature值
            SetPublicParametersValue(obj, signDic);
            //创建URL
            string signUrl = Config.ApiUrl + @"/?" + ObjectToUriParam.Encode(obj);
            return signUrl;
        }

        /// <summary>
        /// 创建默认值
        /// </summary>
        private void SetPublicParametersValue(object obj, Dictionary<string, string> publicPara = null)
        {
            try
            {
                List<PropertyInfo> propertis = obj.GetType().GetProperties().ToList();
                if (publicPara != null && publicPara.Count > 0)
                {
                    foreach (var para in publicPara)
                    {
                        foreach (var item in propertis)
                        {
                            if (para.Key == item.Name)
                            {
                                item.SetValue(obj, para.Value);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in propertis)
                    {
                        if (item.Name == "Version")
                        {
                            item.SetValue(obj, Config.ApiVersion);
                        }
                        if (item.Name == "Format")
                        {
                            item.SetValue(obj, Config.ApiFormat.ToUpper());
                        }
                        else if (item.Name == "AccessKeyId")
                        {
                            item.SetValue(obj, Config.AccessKeyId);
                        }
                        else if (item.Name == "SignatureMethod")
                        {
                            item.SetValue(obj, Config.ApiSignatureMethod);
                        }
                        else if (item.Name == "Timestamp")
                        {
                            item.SetValue(obj, DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
                        }
                        else if (item.Name == "SignatureVersion")
                        {
                            item.SetValue(obj, Config.ApiSignatureVersion);
                        }
                        else if (item.Name == "SignatureNonce")
                        {
                            item.SetValue(obj, Guid.NewGuid().ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"设置公共参数时出错，错误：{ex.Message}");
            }
        }

        private string BuildRequestPara(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("GET");
            sb.Append("&%2F&");
            sb.Append(UrlCode.Encode(str));
            return sb.ToString();
        }
    }
}
