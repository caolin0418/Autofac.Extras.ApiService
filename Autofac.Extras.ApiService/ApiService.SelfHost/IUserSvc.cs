using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.SelfHost
{
    public interface IUserSvc
    {
        bool Add(User user);
    }
}
