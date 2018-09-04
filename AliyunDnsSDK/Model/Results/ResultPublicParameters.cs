using System;
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
        /// <summary>
        /// 唯一请求识别码
        /// </summary>
        public abstract string RequestId { get; set; }
    }
}
