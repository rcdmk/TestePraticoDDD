using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PersonSpecs
{
    public class PersonMustHaveANameBetween2and150ChachactersLongSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.Name);

        public bool IsSatisfiedBy(Person entity)
        {
            return entity.Name.Length >= 2 && entity.Name.Length <= 50;
        }
    }
}
