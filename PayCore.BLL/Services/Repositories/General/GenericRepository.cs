using Microsoft.EntityFrameworkCore;
using PayCore.BLL.Services;
using PayCore.DAL.ORM;
using PayCore.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.BLL.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        internal PayCoreContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(PayCoreContext payCoreContext)
        {
            this.context = payCoreContext;
            this.dbSet = context.Set<T>();
        }


        public virtual T Create(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.AddDate = DateTime.Now;
            entity.IsDeleted = false;

            dbSet.Add(entity);
            return entity;
        }

        public virtual T GetById(Guid id)
        {
            var entity = dbSet.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public virtual List<T> GetAll()
        {
            var result = dbSet.Where(x => x.IsDeleted == false).ToList();
            return result;
        }

        public virtual IQueryable<T> GetAllWithQueryable()
        {
            var result = dbSet.Where(x => x.IsDeleted == false).OrderByDescending(q => q.AddDate);
            return result;
        }

        public T Delete(Guid id)
        {
            var entity = dbSet.FirstOrDefault(y => y.Id == id);


            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;

            return entity;

        }

        public IQueryable<T> GetAllWithExternalQuery(Expression<Func<T, bool>> filter)
        {
            var result = dbSet.Where(q => q.IsDeleted == false).Where(filter);
            return result;
        }
    }
}
