using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaPrecisaTerUmNomeDefinidoSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.Name);

        public bool IsSatisfiedBy(Person entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
