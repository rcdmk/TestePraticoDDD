using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaNaoDeveTerDataDeNascimentoNoFuturoSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.BirthDate);

        public bool IsSatisfiedBy(Person entity)
        {
            return !entity.BirthDate.HasValue || entity.BirthDate <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
