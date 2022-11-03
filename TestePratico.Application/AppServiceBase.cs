using System.Linq.Expressions;
using TestePratico.Application.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Validation;

namespace TestePratico.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> service;

        public AppServiceBase(IServiceBase<TEntity> service)
        {
            this.service = service;
        }

        public virtual TEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return service.Find(filter);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return service.GetAll();
        }

        public virtual ValidationResult Add(TEntity obj)
        {
            return service.Add(obj);
        }

        public virtual ValidationResult Update(TEntity obj)
        {
            return service.Update(obj);
        }

        public virtual ValidationResult Remove(TEntity obj)
        {
            return service.Remove(obj);
        }

        public virtual void SaveChanges()
        {
            service.SaveChanges();
        }

        public virtual void Dispose()
        {
            service.Dispose();
        }
    }
}
