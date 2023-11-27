using PayCore.BLL.Services.Repositories;
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

        public IProductRepository productRepository { get; set; }

       // public IWebUserRepository webUserRepository { get; set; }

        private PayCoreContext _payCoreContext;

        public UnitOfWork(PayCoreContext context)
        {
            _payCoreContext= context;

            categoryRepository = new CategoryRepository(_payCoreContext);
            productRepository= new ProductRepository(_payCoreContext);
          //  webUserRepository = new WebUserRepository(_payCoreContext);
        }

        public void Commit()
        {
            _payCoreContext.SaveChanges();
        }
    }
}
