using TestePratico.Domain.Entities;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Tests.Fakes
{
    public class FakeValidator<TEntity> : Validator<TEntity> where TEntity : EntityBase<TEntity>
    {
        private readonly bool valid;

        public FakeValidator(bool valid)
        {
            this.valid = valid;
        }

        public override ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();

            if (!valid) result.Add("foo", "some error");

            return result;
        }
    }

}
