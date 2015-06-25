using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestePratico.Domain.Validation;

namespace TestePratico.Services.Interfaces
{
	[ServiceContract]
	public interface IAppServiceBase<TEntity> : IDisposable where TEntity : class
	{
		[OperationContract]
		TEntity GetById(int id);

		[OperationContract]
		IEnumerable<TEntity> GetAll();

		[OperationContract]
		ValidationResult Add(TEntity entity);

		[OperationContract]
		ValidationResult Update(TEntity entity);

		[OperationContract]
		ValidationResult Remove(TEntity entity);
	}
}
