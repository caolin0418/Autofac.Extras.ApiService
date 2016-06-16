using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Extras.ApiService
{
    public interface IServiceAction
    {
        object Action(string controllerName, string actionName, string data);
    }
}
