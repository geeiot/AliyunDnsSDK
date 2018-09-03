using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliyunDnsSDK;
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

            //Init DescribeDomainRecords object
            IDescribeDomainRecords describeDomainRecords = new IDescribeDomainRecords()
            {
                DomainName = "1byte.cn"
            };

            //Get and out result
            DomainRecords domain = new DomainRecords();
            domain = request.Request<DescribeDomainRecordsResult>(describeDomainRecords).DomainRecords;
            if (domain != null && domain.Record.Count > 0)
            {
                foreach (var item in domain.Record)
                {
                    Console.WriteLine(item.RecordId + "\t" + item.DomainName + "\t" + item.Status + "\t" + item.RR + "\t" + item.Value);
                }
            }

            Console.ReadKey(false);
        }
    }
}
