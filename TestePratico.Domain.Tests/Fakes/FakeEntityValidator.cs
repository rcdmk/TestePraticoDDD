using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Tests.Fakes
{
    public class FakeEntityValidator : Validator<FakeEntity>
    {
        private readonly bool valid;

        public FakeEntityValidator(bool valid)
        {
            this.valid = valid;
        }

        public override ValidationResult Validate(FakeEntity entity)
        {
            var result = new ValidationResult();

            if (!valid) result.Add("foo", "some error");

            return result;
        }
    }

}
