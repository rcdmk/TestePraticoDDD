using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ValidationResult ValidationResult { get; private set; }

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
            ValidationResult = new ValidationResult();
        }

        private ValidationResult Validate(TEntity obj)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            if (obj is IValidable)
            {
                var validable = (IValidable)obj;

                if (!validable.IsValid)
                    ValidationResult = validable.ValidationResult;
            }

            return ValidationResult;
        }

        public virtual TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return repository.Find(filter);
        }

        public virtual ValidationResult Add(TEntity obj)
        {
            if (Validate(obj).IsValid)
            {
                repository.Add(obj);
            }

            return ValidationResult;
        }

        public virtual ValidationResult Update(TEntity obj)
        {
            if (Validate(obj).IsValid)
            {
                repository.Update(obj);
            }

            return ValidationResult;
        }

        public virtual ValidationResult Remove(TEntity obj)
        {
            if (Validate(obj).IsValid)
            {
                repository.Remove(obj);
            }

            return ValidationResult;
        }

        public virtual void SaveChanges()
        {
            repository.SaveChanges();
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
