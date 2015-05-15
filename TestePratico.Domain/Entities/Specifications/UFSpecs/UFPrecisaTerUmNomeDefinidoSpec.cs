using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.UFSpecs
{
	public class UFPrecisaTerUmNomeDefinidoSpec : ISpecification<UF>
	{
		public string Field
		{
			get { return "Nome"; }
		}

		public bool IsSatisfiedBy(UF entity)
		{
			return !string.IsNullOrWhiteSpace(entity.Nome);
		}
	}
}
