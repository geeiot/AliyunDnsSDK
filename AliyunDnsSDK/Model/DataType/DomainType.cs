﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Model.DataType
{
    /// <summary>
    /// 域名信息的类型。
    /// 节点名：Domain
    /// 更新时间：2017-06-07 13:26:11
    /// </summary>
    public class DomainType : DataTypePublicParameters
    {
        /// <summary>
        /// 域名ID
        /// </summary>
        public string DomainId { get; set; }

        /// <summary>
        /// 域名名称
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 是否为阿里云万网域名
        /// </summary>
        public bool AliDomain { get; set; }

        /// <summary>
        /// 域名分组ID
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 云解析产品ID
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// 云解析版本Code
        /// </summary>
        public string VersionCode { get; set; }

        /// <summary>
        /// 中文域名的punycode码，英文域名返回为空
        /// </summary>
        public string PunyCode { get; set; }

        /// <summary>
        /// 域名在解析系统中的DNS列表
        /// </summary>
        public DnsServerType DnsServers { get; set; }

    }
}
