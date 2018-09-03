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
            IAddDomainRecord describeDomainRecords = new IAddDomainRecord()
            {
                DomainName = "1byte.cn",
                RR = "test",
                Type = ResolveLogFormat.A,
                Value = "192.168.1.100"
            };

            //Get and out result
            AddDomainRecordResult result = request.Request<AddDomainRecordResult>(describeDomainRecords, true);
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
