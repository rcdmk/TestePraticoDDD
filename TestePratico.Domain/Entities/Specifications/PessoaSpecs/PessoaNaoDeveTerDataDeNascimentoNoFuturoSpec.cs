using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaNaoDeveTerDataDeNascimentoNoFuturoSpec : ISpecification<Pessoa>
    {
        public string Field
        {
            get { return "DataNascimento"; }
        }

        public bool IsSatisfiedBy(Pessoa entity)
        {
            return !entity.DataNascimento.HasValue || entity.DataNascimento <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
