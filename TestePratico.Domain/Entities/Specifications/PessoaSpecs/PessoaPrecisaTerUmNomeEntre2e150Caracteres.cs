using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaPrecisaTerUmNomeEntre2e150Caracteres : ISpecification<Pessoa>
    {
        public string Field => nameof(Pessoa.Nome);

        public bool IsSatisfiedBy(Pessoa entity)
        {
            return entity.Nome.Length >= 2 && entity.Nome.Length <= 50;
        }
    }
}
