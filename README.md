# AliyunDdns
阿里云解析接口SDK，可以使用本SDK对域名解析进行相关操作。请确保在使用这些接口前，已充分了解阿里云解析产品说明和使用协议。<br />

**如何使用**

1、配置<br />
在项目Config文件的appSettings节点下面配置以下参数。<br />
```csharp
<appSettings>
    <!--请修改你的AccessKeyId和AccessKeySecret-->
    <add key="AccessKeyId" value="你的AccessKeyId"/>
    <add key="AccessKeySecret" value="你的AccessKeySecret"/>
    <!--以下设置保持默认值请不要修改-->
    <add key="ApiUrl" value="http://alidns.aliyuncs.com"/>
    <add key="ApiFormat" value="JSON"/>
    <add key="ApiVersion" value="2015-01-09"/>
    <add key="ApiSignatureMethod" value="HMAC-SHA1"/>
    <add key="ApiSignatureVersion" value="1.0"/>
</appSettings>
```

2、添加相关的模型<br />
项目开发初期，大多数模型未添加，需要哪些模型，自行添加即可。对于Result实体，可以将官方文档提供的JSON格式数据提供下面的工具直接转化为实体模型。工具地址：http://www.bejson.com/convert/json2csharp/ <br />

3、代码使用（Demo）<br />
```csharp
//Init Api
AliyunDnsApi request = new AliyunDnsApi();

//New接口类
DescribeDomainRecords describeDomainRecords = new DescribeDomainRecords()
{
    DomainName = "example.com"
};

//获取和输出数据
IDomainRecords domain = new IDomainRecords();
domain = request.Request<DescribeDomainRecordsResult>(describeDomainRecords).DomainRecords; //泛型参数为Result实体模型
if (domain != null && domain.Record.Count > 0)
{
    foreach (var item in domain.Record)
    {
        Console.WriteLine(item.RecordId + "\t" + item.DomainName + "\t" + item.Status + "\t" + item.RR + "\t" + item.Value);
    }
}
```

4、目前可用接口
AddDomain 添加域名
DeleteDomain 删除域名
DescribeDomains 获取域名列表
DescribeDomainInfo 获取域名信息
IModifyHichinaDomainDNS 修改万网域名DNS

DescribeDomainRecords 获取解析记录列表
