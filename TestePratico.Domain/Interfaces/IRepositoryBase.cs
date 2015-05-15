using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Domain.Interfaces
{
	public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class 
	{
		void Add(TEntity obj);
		
		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll();

		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

		void Update(TEntity obj);

		void Remove(TEntity obj);

		void SaveChanges();
	}
}
