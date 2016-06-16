using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.SelfHost
{
    public class UserSvc : IUserSvc
    {
        public bool Add(User user)
        {
            return user.Id == "1";
        }
    }
}
