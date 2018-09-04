using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Model.Requests
{
    /// <summary>
    /// 获取域名信息
    /// 更新时间：2017-06-07 13:26:11
    /// 文档地址：https://help.aliyun.com/document_detail/29752.html?spm=a2c4g.11186623.6.618.2b5446femKb9a2
    /// </summary>
    public class IDescribeDomainInfo : InterfacePublicParameters
    {
        public string Action
        {
            get
            {
                return "DescribeDomainInfo";
            }
        }

        public string DomainName { get; set; }

        //=========================================================================

        public override string Format { get; set; }

        public override string Version { get; set; }

        public override string AccessKeyId { get; set; }

        public override string Signature { get; set; }

        public override string SignatureMethod { get; set; }

        public override string Timestamp { get; set; }

        public override string SignatureVersion { get; set; }

        public override string SignatureNonce { get; set; }
    }
}
