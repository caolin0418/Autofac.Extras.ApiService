# Autofac.Extras.ApiService
让Service自动变成Web API


SelfHost:
```csharp
using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
{
      var builder = new ContainerBuilder();
      server.Configuration.InitApiService(builder);
      ...
}
```


WebHost:



Test:  

- 运行项目

- 浏览器打开http://localhost:10000/api/svc

- 显示HelloWorld即表示成功
