using PayCore.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; set; }

        private PayCoreContext _payCoreContext;

        public UnitOfWork(PayCoreContext context)
        {
            _payCoreContext= context;

            categoryRepository = new CategoryRepository(_payCoreContext);
        }

    
    }
}
