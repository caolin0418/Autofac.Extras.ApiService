using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace Autofac.Extras.ApiService
{
    public static class HttpConfigurationInit
    {
        public static void InitApiService(this HttpConfiguration config, ContainerBuilder builder)
        {
            InitApiService(config, builder, new HttpRoute("api/svc/{service}/{method}", new HttpRouteValueDictionary { { "service", "" }, { "method", "Index" } }));
        }
        public static void InitApiService(this HttpConfiguration config, ContainerBuilder builder, HttpRoute route)
        {
            config.Routes.Add("api", route);
            config.Services.Replace(typeof(IHttpControllerSelector), new HttpControllerSelect(config));
            builder.RegisterType<DynamicController>().AsSelf();
            builder.RegisterType<ServiceAction>().AsImplementedInterfaces();
        }
    }
}
