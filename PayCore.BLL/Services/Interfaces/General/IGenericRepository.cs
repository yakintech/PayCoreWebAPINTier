using PayCore.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);

        T Create(T entity);

        List<T> GetAll();

        IQueryable<T> GetAllWithQueryable();

    }
}
