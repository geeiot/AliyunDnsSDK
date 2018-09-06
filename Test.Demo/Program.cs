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
            ShowDomainGroup();  //c291db4a-cc3e-4276-b6dc-4e6c3f881286
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //Init DescribeDomainRecords object
            IUpdateDomainGroup describeDomainRecords = new IUpdateDomainGroup()
            {
                GroupId = "c291db4a-cc3e-4276-b6dc-4e6c3f881286",
                GroupName = "测试"
            };

            //Get and out result
            UpdateDomainGroupResult result = request.Request<UpdateDomainGroupResult>(describeDomainRecords, true);
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
            Console.WriteLine();
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
            //Init Api
            AliyunDnsApi request = new AliyunDnsApi();

            //Init DescribeDomainRecords object
            IDescribeDomainGroups describeDomainRecords = new IDescribeDomainGroups();

            DescribeDomainGroupsResult domain = request.Request<DescribeDomainGroupsResult>(describeDomainRecords); //泛型参数为Result实体模型

            if (domain != null)
            {
                foreach(var item in domain.DomainGroups.DomainGroup)
                {
                    Console.WriteLine($"分组ID：{item.GroupId}\t分组名称：{item.GroupName}");
                }
            }
            else
            {
                Console.WriteLine("获取域名分组列表失败！");
            }
            Console.WriteLine();
        }
    }
}
