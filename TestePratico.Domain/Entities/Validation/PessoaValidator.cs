using TestePratico.Domain.Entities.Specifications.PessoaSpecs;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities.Validation
{
    public class PessoaValidator : Validator<Person>
    {
        public PessoaValidator()
        {
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmNomeDefinidoSpec(), "É obrigatório informar um nome"));
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmNomeEntre2e150Caracteres(), "O nome precisa ter entre 2 e 150 caracteres"));
            AddRule(new ValidationRule<Person>(new PessoaPrecisaTerUmaUFDefinidaSpec(), "É obrigatório selecionar uma UF"));
            AddRule(new ValidationRule<Person>(new PessoaNaoDeveTerDataDeNascimentoNoFuturoSpec(), "A data de nascimento não pode ser no futuro"));
        }
    }
}
