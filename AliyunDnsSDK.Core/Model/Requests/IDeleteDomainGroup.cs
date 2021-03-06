﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Core.Model.Requests
{
    /// <summary>
    /// 删除域名分组
    /// 更新时间：2017-06-07 13:26:11
    /// 文档地址：https://help.aliyun.com/document_detail/29764.html?spm=a2c4g.11186623.6.628.1c252a2fkDyKEO
    /// </summary>
    public class IDeleteDomainGroup : InterfacePublicParameters
    {
        /// <summary>
        /// 操作接口名，系统规定参数，取值：DeleteDomainGroup
        /// </summary>
        public string Action
        {
            get
            {
                return "DeleteDomainGroup";
            }
        }

        /// <summary>
        /// 域名分组ID
        /// </summary>
        public string GroupId { get; set; }
    }
}
