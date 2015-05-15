using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Data.Context;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Data.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class 
	{
		protected TestePraticoContext Db = new TestePraticoContext();

		public void Add(TEntity obj)
		{
			Db.Set<TEntity>().Add(obj);
		}

		public TEntity GetById(int id)
		{
			return Db.Set<TEntity>().Find(id);
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
			if (Db.Entry(obj).State == System.Data.Entity.EntityState.Detached) Db.Set<TEntity>().Attach(obj);
			Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;	
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
