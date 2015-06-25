using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Domain.Validation
{
	public class ValidationError
	{
		public string Field { get; private set; }
		public string Message { get; private set; }

		public ValidationError(string field, string message)
		{
			Field = field;
			Message = message;
		}
	}
}
