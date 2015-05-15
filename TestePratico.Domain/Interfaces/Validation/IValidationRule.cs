using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Domain.Interfaces.Validation
{
	public interface IValidationRule<in TEntity>
	{
		string ErrorMessage { get; }
		bool Valid(TEntity entity);
	}
}
