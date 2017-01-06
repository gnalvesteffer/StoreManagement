using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
