using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Autofac.Extras.ApiService
{
    public class ServiceAction: IServiceAction
    {
        private ILifetimeScope _container;
        public ServiceAction(ILifetimeScope container)
        {
            _container = container;
        }
        public object Action(string controllerName, string actionName, string data)
        {
            var types = Assembly.GetCallingAssembly().GetTypes();
            var type = types.First(x => x.Name.ToLower() == controllerName);
            var user = _container.Resolve(type);
            var methods = user.GetType().GetMethods();
            var method = methods.First(x => x.Name.ToLower() == actionName);
            var paraType = method.GetParameters().First().ParameterType;
            var para = JsonConvert.DeserializeObject(data, paraType);
            var rst = method.Invoke(user, new[] { para });
            return rst;
        }
    }
}
