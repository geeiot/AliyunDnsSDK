using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliyunDnsSDK;
using AliyunDnsSDK.Model.DataType;
using AliyunDnsSDK.Model.Interfaces;
using AliyunDnsSDK.Model.Results;

namespace Test.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //实例化接口类
            IDescribeDomainRecords describeDomainRecords = new IDescribeDomainRecords()
            {
                DomainName = "geeiot.net"
            };

            //获取和输出数据
            DomainRecords domain = new DomainRecords();
            domain = request.Request<DescribeDomainRecordsResult>(describeDomainRecords).DomainRecords; //泛型参数为Result实体模型
            if (domain != null && domain.Record.Count > 0)
            {
                foreach (var item in domain.Record)
                {
                    Console.WriteLine(item.RecordId + "\t" + item.DomainName + "\t" + item.Status + "\t" + item.RR + "\t" + item.Value);
                }
            }
            else
            {
                Console.WriteLine("请求失败！");
            }

            Console.ReadKey(false);
        }
    }
}
