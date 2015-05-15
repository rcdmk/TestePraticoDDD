using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
	public class UF : IValidable
	{
		public int IdUF { get; set; }
		public string Nome { get; set; }

		public virtual List<Pessoa> Pessoas { get; set; }

		public ValidationResult ValidationResult { get; private set; }

		public bool IsValid
		{
			get
			{
				ValidationResult = new UFValidator().Validate(this);

				return ValidationResult.IsValid;
			}
		}
	}
}
