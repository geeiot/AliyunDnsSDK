using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliyunDnsSDK;
using AliyunDnsSDK.Model.DataType;
using AliyunDnsSDK.Model.EnumType;
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
            ICheckDomainRecord describeDomainRecords = new ICheckDomainRecord()
            {
                DomainName = "geeiot.net",
                Type = ResolveLogFormat.A.ToString(),
                RR = "www",
                Value = "132.232.22.114"
            };

            //Get and out result
            CheckDomainRecordResult result = request.Request<CheckDomainRecordResult>(describeDomainRecords, true);
            if (result == null)
            {
                Console.WriteLine("请求失败！");
            }
            else
            {
                Console.WriteLine("请求成功！");
            }

            Console.ReadKey(false);
        }
    }
}
