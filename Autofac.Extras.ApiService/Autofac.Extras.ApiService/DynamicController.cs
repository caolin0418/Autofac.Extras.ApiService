using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Autofac.Extras.ApiService
{
    public class DynamicController : ApiController
    {
        readonly IServiceAction _serviceAction;
        public DynamicController(IServiceAction serviceAction)
        {
            this._serviceAction = serviceAction;
        }

        public async Task<object> Post()
        {
            var values = Configuration.Routes.GetRouteData(Request).Values;
            var service = values["service"].ToString();
            var method = values["method"].ToString();
            var data = await Request.Content.ReadAsStringAsync();
            return _serviceAction.Action(service, method, data);
        }
    }
}
