﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Model.DataType
{
    /// <summary>
    /// 列举域名在解析系统中的DNS列表的类型。
    /// </summary>
    public class DnsServerType: DataTypePublicParameters
    {
        /// <summary>
        /// DNS服务器名称，如dns1.hichina.com
        /// 节点名：DnsServer
        /// 更新时间：2017-06-07 13:26:11
        /// </summary>
        public string DnsServer { get; set; }
    }
}