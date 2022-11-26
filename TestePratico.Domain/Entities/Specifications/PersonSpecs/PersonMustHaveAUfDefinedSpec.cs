using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PersonSpecs
{
    public class PersonMustHaveAUfDefinedSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.UFId);

        public bool IsSatisfiedBy(Person entity)
        {
            return entity.UFId.HasValue;
        }
    }
}
