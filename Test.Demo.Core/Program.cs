using AliyunDnsSDK.Core;
using AliyunDnsSDK.Core.Model.Requests;
using AliyunDnsSDK.Core.Model.Results;
using System;

namespace Test.Demo.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowDescribeDomainRecordsList();
            Console.ReadKey(false);
        }

        static void ShowDescribeDomainRecordsList()
        {
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi("你的AccessKeyId", "你的AccessKeySecret");

            //Init DescribeDomainRecords object
            IDescribeDomainRecords describeDomainRecords = new IDescribeDomainRecords()
            {
                DomainName = "quarkbook.com",
            };

            //Get and out result
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
            Console.WriteLine();
        }
    }
}
