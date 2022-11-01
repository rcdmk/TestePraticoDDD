using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaPrecisaTerUmNomeDefinidoSpec : ISpecification<Pessoa>
    {
        public string Field => nameof(Pessoa.Nome);

        public bool IsSatisfiedBy(Pessoa entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Nome);
        }
    }
}
