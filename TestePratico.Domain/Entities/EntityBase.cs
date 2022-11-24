using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public abstract class EntityBase<TEntity> : IValidable where TEntity : EntityBase<TEntity>
    {
        protected EntityBase(Validator<TEntity> validator)
        {
            this.ValidationResult = new ValidationResult();
            this.Validator = validator;
        }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }


        public ValidationResult ValidationResult { get; protected set; }

        protected Validator<TEntity> Validator { get; set; }

        public bool IsValid
        {
            get
            {
                ValidationResult = Validator.Validate((this as TEntity)!);

                return ValidationResult.IsValid;
            }
        }
    }
}
