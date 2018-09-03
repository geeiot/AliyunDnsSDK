using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliyunDnsSDK.Model.DataType;

namespace AliyunDnsSDK.Model.Results
{
    /// <summary>
    /// 域名解析列表返回数据模型
    /// 可通过 http://www.bejson.com/convert/json2csharp/ 此工具直接将阿里云给出的JSON转化为实体模型
    /// </summary>
    public class DescribeDomainRecordsResult : ResultPublicParameters
    {
        /// <summary>
        /// 解析记录总数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public long PageNumber { get; set; }

        /// <summary>
        /// 本次查询获取的解析数量
        /// </summary>
        public long PageSize { get; set; }

        /// <summary>
        /// 解析记录列表
        /// </summary>
        public DomainRecords DomainRecords { get; set; }

        //========================================================

        public override string RequestId { get; set; }
    }

    public class DomainRecords
    {
        public List<RecordType> Record { get; set; }
    }
}
