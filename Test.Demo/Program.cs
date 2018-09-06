using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliyunDnsSDK;
using AliyunDnsSDK.Model.DataType;
using AliyunDnsSDK.Model.EnumType;
using AliyunDnsSDK.Model.Requests;
using AliyunDnsSDK.Model.Results;

namespace Test.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDescribeDomainRecords();
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //Init DescribeDomainRecords object
            IAddDomainGroup describeDomainRecords = new IAddDomainGroup()
            {
                GroupName = "出售"
            };

            //Get and out result
            AddDomainGroupResult result = request.Request<AddDomainGroupResult>(describeDomainRecords, true);
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

        static void GetDescribeDomainRecords()
        {
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //Init DescribeDomainRecords object
            IDescribeDomainRecords describeDomainRecords = new IDescribeDomainRecords()
            {
                DomainName = "1byte.cn",
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
        }

        static void AddDomainRecord()
        {
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //Init DescribeDomainRecords object
            IAddDomainRecord describeDomainRecords = new IAddDomainRecord()
            {
                DomainName = "1byte.cn",
                RR = "yr",
                Type = ResolveLogFormat.A,
                Value = "1.1.1.1"
            };

            AddDomainResult domain = request.Request<AddDomainResult>(describeDomainRecords); //泛型参数为Result实体模型

            if (domain != null)
            {
                Console.WriteLine("添加成功！");
            }
            else
            {
                Console.WriteLine("添加失败！");
            }
        }

        static void ShowDomainGroup()
        {

        }
    }
}
