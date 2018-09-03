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

            //Init DescribeDomainRecords object
            IDescribeDomainInfo describeDomainRecords = new IDescribeDomainInfo()
            {
                DomainName = "geeiot.net",
            };

            //Get and out result
            DescribeDomainInfoResult result = request.Request<DescribeDomainInfoResult>(describeDomainRecords, true);
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
