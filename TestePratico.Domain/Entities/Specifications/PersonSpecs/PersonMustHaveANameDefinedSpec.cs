using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PersonSpecs
{
    public class PersonMustHaveANameDefinedSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.Name);

        public bool IsSatisfiedBy(Person entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
