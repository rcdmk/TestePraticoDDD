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
        public string Field => nameof(Person.Birthdate);

        public bool IsSatisfiedBy(Person entity)
        {
            return !entity.Birthdate.HasValue || entity.Birthdate <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
