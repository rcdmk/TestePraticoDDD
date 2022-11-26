using TestePratico.Domain.Entities.Specifications.PessoaSpecs;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities.Validation
{
    public class PersonValidator : Validator<Person>
    {
        public PersonValidator()
        {
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmNomeDefinidoSpec(), "It is required to provide a name"));
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmNomeEntre2e150Caracteres(), "Name must have between 2 and 150 characters"));
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmaUFDefinidaSpec(), "It's required to select an UF"));
            AddRule(new ValidationRule<Person>(new PessoaNaoDeveTerDataDeNascimentoNoFuturoSpec(), "Birthdate can't be in the future"));
        }
    }
}
