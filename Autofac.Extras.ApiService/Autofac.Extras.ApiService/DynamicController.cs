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

        [HttpGet]
        public string Index()
        {
            return "HelloWorld";
        }

        public async Task<object> Post()
        {
            var values = Configuration.Routes.GetRouteData(Request).Values;
            var service = values["service"].ToString();
            var method = values["method"].ToString();
            if (service == "" && method == "Index")
            {
                return Index();
            }
            var data = await Request.Content.ReadAsStringAsync();
            return _serviceAction.Action(service, method, data);
        }
    }
}
