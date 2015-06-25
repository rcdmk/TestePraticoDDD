using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Validation;
using TestePratico.Services.Interfaces;

namespace TestePratico.Services
{
	public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
	{
		protected IServiceBase<TEntity> domainService;

		public AppServiceBase(IServiceBase<TEntity> domainService)
		{
			this.domainService = domainService;
		}

		public TEntity GetById(int id)
		{
			return domainService.GetById(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return domainService.GetAll();
		}

		public ValidationResult Add(TEntity obj)
		{
			var result = domainService.Add(obj);

			if (result.IsValid)
				domainService.SaveChanges();

			return result;
		}

		public ValidationResult Update(TEntity obj)
		{
			var result = domainService.Update(obj);

			if (result.IsValid)
				domainService.SaveChanges();

			return result;
		}

		public ValidationResult Remove(TEntity obj)
		{
			var result = domainService.Remove(obj);

			if (result.IsValid)
				domainService.SaveChanges();

			return result;
		}

		public void Dispose()
		{
			domainService.Dispose();
		}
	}
}