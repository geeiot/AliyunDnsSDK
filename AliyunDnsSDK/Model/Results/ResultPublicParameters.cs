﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliyunDnsSDK.Model.Results
{
    /// <summary>
    /// 返回公共参数
    /// </summary>
    public abstract class ResultPublicParameters
    {
        public abstract string RequestId { get; set; }
    }
}