using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.UFSpecs
{
    public class UFMustHaveANameBetween2and50CharactersLongSpec : ISpecification<UF>
    {
        public string Field => nameof(UF.Name);

        public bool IsSatisfiedBy(UF entity)
        {
            return entity.Name.Length >= 2 && entity.Name.Length <= 50;
        }
    }
}
