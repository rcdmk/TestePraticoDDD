using TestePratico.Domain.Entities.Specifications.PessoaSpecs;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities.Validation
{
    public class PessoaValidator : Validator<Pessoa>
    {
        public PessoaValidator()
        {
            AddRule(new ValidationRule<Pessoa>(new PessoaPrecisaTerUmNomeDefinidoSpec(), "É obrigatório informar um nome"));
            AddRule(new ValidationRule<Pessoa>(new PessoaPrecisaTerUmNomeEntre2e150Caracteres(), "O nome precisa ter entre 2 e 150 caracteres"));
            AddRule(new ValidationRule<Pessoa>(new PessoaPrecisaTerUmaUFDefinidaSpec(), "É obrigatório selecionar uma UF"));
            AddRule(new ValidationRule<Pessoa>(new PessoaNaoDeveTerDataDeNascimentoNoFuturoSpec(), "A data de nascimento não pode ser no futuro"));
        }
    }
}
