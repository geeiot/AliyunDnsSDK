# AliyunDdns
阿里云解析接口SDK，可以使用本SDK对域名解析进行相关操作。请确保在使用这些接口前，已充分了解阿里云解析产品说明和使用协议。<br />
- SDK支持API版本：2015-01-09
- SDK支持最新版本：OpenAPI V2.0.1

**如何使用**

1、配置<br />
有两种配置方法。<br />
第一种，在项目Config文件的appSettings节点下面配置以下参数。（不支持.NET Core）<br />
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
第二种，在构造Api的时候，填写参数AccessKeyId和AccessKeySecret。<br />
```csharp
AliyunDnsApi request = new AliyunDnsApi("你的AccessKeyId", "你的AccessKeySecret");
```

2、代码使用（Demo）<br />
```csharp
//Init Api
AliyunDnsApi request = new AliyunDnsApi();

//实例化接口类
IDescribeDomainRecords describeDomainRecords = new IDescribeDomainRecords()
{
    DomainName = "geeiot.net"
};

//获取和输出数据
DomainRecords domain =  request.Request<DescribeDomainRecordsResult>(describeDomainRecords).DomainRecords; //泛型参数为Result实体模型
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
```

3、目前可用接口<br />
由于个人精力和条件有限，并未测试全部的接口，对于未测试接口，请自行测试并Debug，或者提交相关Issue。<br />

| 序号  | 接口值  | 接口名称 | 是否测试 |  描述  |
| ------------ | ------------ | ------- |------------ | ------------ |
| 1  | IAddDomain  | 添加域名  | 是  | 见官网  |
| 2  | IDeleteDomain  | 删除域名  | 是  |  见官网 |
| 3  | IDescribeDomains  | 获取域名列表  | 是  |  见官网 |
| 4  | IDescribeDomainInfo  | 获取域名信息  | 是  |  见官网 |
| 5  | IModifyHichinaDomainDNS  | 修改万网域名DNS  | 是  |  见官网 |
| 6  | IGetMainDomainName  | 获取主域名名称   | 是  | 见官网  |
| 7  | IDescribeDomainLogs  | 获取域名操作日志   | 是  | 见官网  |
| 8  | IDescribeDnsProductInstances  | 获取云解析收费版本产品列表   | 是  | 见官网  |
| 9  | IChangeDomainOfDnsProduct  | 更换云解析产品绑定的域名   | 否  | 见官网  |
| 10  | ICheckDomainRecord  | 检测解析记录是否生效   | 是  | [点此查看](https://help.aliyun.com/document_detail/29770.html?spm=a2c4g.11186623.6.632.57482a2fJsIWI8 "点此查看")  |
| 11  | IAddDomainRecord  | 添加解析记录   | 是  | [点此查看](https://help.aliyun.com/document_detail/29772.html?spm=a2c4g.11186623.6.634.1a2c7d8c0ELy4p "点此查看") |
| 12  | IDeleteDomainRecord  | 删除解析记录   | 是  | [点此查看](https://help.aliyun.com/document_detail/29773.html?spm=a2c4g.11186623.6.635.5cff47d9MTmKi2 "点此查看") |
| 13  | IUpdateDomainRecord  | 修改解析记录   | 是  | [点此查看](https://help.aliyun.com/document_detail/29774.html?spm=a2c4g.11186623.6.636.208f2911qU30OW "点此查看") |
| 14  | ISetDomainRecordStatus  | 设置解析记录状态   | 是  | [点此查看](https://help.aliyun.com/document_detail/29775.html?spm=a2c4g.11186623.6.637.68ca6e00pErW5k "点此查看") |
| 15  | IDescribeDomainRecords  | 获取解析记录列表   | 是  | [点此查看](https://help.aliyun.com/document_detail/29776.html?spm=a2c4g.11186623.6.638.79be2911qegwNF "点此查看") |
| 16  | IDescribeDomainRecordInfo  | 获取解析记录信息   | 是  | [点此查看](https://help.aliyun.com/document_detail/29777.html?spm=a2c4g.11186623.6.639.73114c25AT5ItS "点此查看")|
| 17  | IDescribeSubDomainRecords   | 获取子域名的解析记录列表   | 是  | [点此查看](https://help.aliyun.com/document_detail/29778.html?spm=a2c4g.11186623.6.640.798347d93OwMQN "点此查看")  |
| 18  | IDeleteSubDomainRecords  | 删除主机记录对应的解析记录   | 是  | [点此查看](https://help.aliyun.com/document_detail/29779.html?spm=a2c4g.11186623.6.641.55bb5684TOnon4 "点此查看")  |
| 19  | IDescribeRecordLogs  | 获取域名的解析操作日志   | 是  | [点此查看](https://help.aliyun.com/document_detail/29780.html?spm=a2c4g.11186623.6.642.111e2b4bFa4xyX "点此查看")  |
| 20  | ISetDNSSLBStatus  | 开启/关闭解析负载均衡   | 是  | [点此查看](https://help.aliyun.com/document_detail/29782.html?spm=a2c4g.11186623.6.644.ab015684lMjNo3 "点此查看")  |
| 21  | IDescribeDNSSLBSubDomains  | 获取解析负载均衡的子域名列表   | 是  | [点此查看](https://help.aliyun.com/document_detail/29783.html?spm=a2c4g.11186623.6.645.1b574c25bnb0i4 "点此查看")  |
| 22  | IUpdateDNSSLBWeight  | 修改解析负载均衡权重   | 否  | [点此查看](https://help.aliyun.com/document_detail/29784.html?spm=a2c4g.11186623.6.646.79e527d6KMjZ5g "点此查看")  |
| 23  | IAddDomainGroup  | 添加域名分组   | 是  | [点此查看](https://help.aliyun.com/document_detail/29762.html?spm=a2c4g.11186623.6.626.d8a76aabw0T2tJ "点此查看")  |
| 24  | IUpdateDomainGroup  | 修改域名分组   | 是  | [点此查看](https://help.aliyun.com/document_detail/29763.html?spm=a2c4g.11186623.6.627.6533698efJi0FF "点此查看")  |
| 25  | IDeleteDomainGroup  | 删除域名分组   | 是  | [点此查看](https://help.aliyun.com/document_detail/29764.html?spm=a2c4g.11186623.6.628.1c252a2fkDyKEO "点此查看")  |
| 26  | IChangeDomainGroup  | 更换域名分组   | 是  | [点此查看](https://help.aliyun.com/document_detail/29765.html?spm=a2c4g.11186623.6.629.477a59c8CeLeTd "点此查看")  |
| 27  | IDescribeDomainGroups  | 获取域名分组列表   | 是  | [点此查看](https://help.aliyun.com/document_detail/29766.html?spm=a2c4g.11186623.6.630.3b755ce5jjpZAB "点此查看")  |
