using PayCore.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCore.DAL.ORM.Entity.User;

namespace PayCore.BLL.Services.Repositories
{
    internal class WebUserRepository 
    {
       
        public WebUser UpdateRefreshToken(string refreshToken, string email) 
        {
            using (PayCoreContext db = new PayCoreContext())
            {
                //var webuser = db.WebUsers.FirstOrDefault(q => q.EMail ==)
            }
            return null;
        }
    }
}

