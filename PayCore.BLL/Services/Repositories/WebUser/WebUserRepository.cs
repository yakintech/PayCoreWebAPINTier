using PayCore.DAL.ORM.Context;
using PayCore.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayCore.BLL.Services.Interfaces;

namespace PayCore.BLL.Services.Repositories
{
    internal class WebUserRepository : GenericRepository<WebUser>, IWebUserRepository
    {
        public WebUserRepository(PayCoreContext context) : base(context)
        {

        }

    }
}

