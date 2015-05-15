using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Interfaces.Services
{
	public interface IServiceBase<TEntity> : IDisposable where TEntity : class
	{

		TEntity GetById(int id);

		IEnumerable<TEntity> GetAll();

		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

		ValidationResult Add(TEntity obj);

		ValidationResult Update(TEntity obj);

		ValidationResult Remove(TEntity obj);

		void SaveChanges();
	}
}
