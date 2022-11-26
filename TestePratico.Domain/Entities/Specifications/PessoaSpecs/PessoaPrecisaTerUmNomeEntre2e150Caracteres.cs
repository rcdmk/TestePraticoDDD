using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PessoaSpecs
{
    public class PessoaPrecisaTerUmNomeEntre2e150Caracteres : ISpecification<Person>
    {
        public string Field => nameof(Person.Name);

        public bool IsSatisfiedBy(Person entity)
        {
            return entity.Name.Length >= 2 && entity.Name.Length <= 50;
        }
    }
}
