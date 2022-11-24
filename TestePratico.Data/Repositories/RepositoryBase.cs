using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Db;

        public RepositoryBase(DbContext db)
        {
            Db = db;
        }

        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id)!;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return Db.Set<TEntity>().Where(filter).ToList();
        }

        public virtual void Update(TEntity obj)
        {
            if (Db.Entry(obj).State == EntityState.Detached) Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public virtual void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
