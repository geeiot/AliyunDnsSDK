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
            IAddDomain describeDomainRecords = new IAddDomain()
            {
                DomainName = "quarkbook.com"
            };

            //Get and out result
            List<DnsServerType> dnsServers = new List<DnsServerType>();
            AddDomainResult result = request.Request<AddDomainResult>(describeDomainRecords,true);
            if (result == null)
            {
                Console.WriteLine("请求失败！");
            }
            else
            {
                dnsServers = result.DnsServers.DnsServer;
            }


            Console.ReadKey(false);
        }
    }
}
