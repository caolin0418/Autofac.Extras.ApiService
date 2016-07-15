# Autofac.Extras.ApiService
让Service自动变成Web API


###SelfHost
```csharp
using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
{
      var builder = new ContainerBuilder();
      server.Configuration.InitApiService(builder);
      ...
}
```


###WebHost
```csharp
var builder = new ContainerBuilder();
GlobalConfiguration.Configuration.InitApiService(builder);
...
```

###Test

- 运行项目

- 浏览器打开http://localhost:10000/api/svc

- 显示HelloWorld即表示成功


###限制

- 只支持从报文体中对参数赋值
- 方法名不支持重名
- 使用该方式将自动取消Web API默认功能
