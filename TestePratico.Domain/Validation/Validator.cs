using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Validation
{
    public class Validator<TEntity> : IValidator<TEntity>
    {
        protected readonly List<IValidationRule<TEntity>> rules;

        public Validator()
        {
            rules = new List<IValidationRule<TEntity>>();
        }

        protected virtual void AddRule(IValidationRule<TEntity> rule)
        {
            rules.Add(rule);
        }

        protected virtual void RemoveRule(IValidationRule<TEntity> rule)
        {
            rules.Remove(rule);
        }

        public ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();

            foreach (var rule in rules)
            {
                if (!rule.Valid(entity)) result.Add(rule.Field, rule.ErrorMessage);
            }

            return result;
        }
    }
}
