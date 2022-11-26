using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.UFSpecs
{
    public class UFMustHaveANameDefinedSpec : ISpecification<UF>
    {
        public string Field => nameof(UF.Name);

        public bool IsSatisfiedBy(UF entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
