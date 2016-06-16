using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Autofac.Extras.ApiService
{
    internal class HttpControllerSelect : IHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;

        public HttpControllerSelect(HttpConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return new HttpControllerDescriptor(_configuration, string.Empty, typeof(DynamicController));
        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
        }
    }
}
