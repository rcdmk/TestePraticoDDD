using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Interfaces.Validation
{
	public interface IValidable
	{
		ValidationResult ValidationResult { get; }
		bool IsValid { get; }
	}
}
