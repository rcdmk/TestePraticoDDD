using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.PersonSpecs
{
    public class PersonCantHaveBirthdateInTheFutureSpec : ISpecification<Person>
    {
        public string Field => nameof(Person.Birthdate);

        public bool IsSatisfiedBy(Person entity)
        {
            return !entity.Birthdate.HasValue || entity.Birthdate <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}
