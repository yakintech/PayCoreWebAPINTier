using PayCore.DAL.ORM;
using PayCore.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
  public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PayCoreContext context) : base(context)
        {

        }

    }
}
