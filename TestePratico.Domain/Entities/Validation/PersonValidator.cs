using TestePratico.Domain.Entities.Specifications.PersonSpecs;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities.Validation
{
    public class PersonValidator : Validator<Person>
    {
        public PersonValidator()
        {
            AddRule(new ValidationRule<Person>(new PersonMustHaveANameDefinedSpec(), "It is required to provide a name"));
            AddRule(new ValidationRule<Person>(new PersonMustHaveANameBetween2and150ChachactersLongSpec(), "Name must have between 2 and 150 characters"));
            AddRule(new ValidationRule<Person>(new PersonMustHaveAUfDefinedSpec(), "It's required to select an UF"));
            AddRule(new ValidationRule<Person>(new PersonCantHaveBirthdateInTheFutureSpec(), "Birthdate can't be in the future"));
        }
    }
}
