using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaPrecisaTerUmaUFDefinidaSpec : ISpecification<Pessoa>
    {
        public string Field
        {
            get { return "UFId"; }
        }

        public bool IsSatisfiedBy(Pessoa entity)
        {
            return entity.UFId.HasValue;
        }
    }
}
