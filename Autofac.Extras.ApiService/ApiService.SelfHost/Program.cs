using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Extras.ApiService;
using Autofac.Integration.WebApi;

namespace ApiService.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new HttpSelfHostServer(new HttpSelfHostConfiguration("http://localhost:10000")))
            {
                var builder = new ContainerBuilder();
                server.Configuration.InitApiService(builder);
                builder.RegisterAssemblyTypes(typeof(UserSvc).Assembly).AsImplementedInterfaces().AsSelf();
                var container = builder.Build();
                server.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                server.OpenAsync();
                Console.WriteLine("开启服务成功");
                Console.ReadKey();
            }
        }
    }
}
