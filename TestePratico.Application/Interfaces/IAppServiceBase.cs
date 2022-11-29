using System.Linq.Expressions;
using TestePratico.Domain.Validation;

namespace TestePratico.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> : IDisposable where TEntity : class
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
