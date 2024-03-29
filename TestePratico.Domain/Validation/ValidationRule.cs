﻿using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Validation
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        protected readonly ISpecification<TEntity> specification;

        public string Field { get; private set; }
        public string ErrorMessage { get; private set; }

        public bool Valid(TEntity entity)
        {
            return specification.IsSatisfiedBy(entity);
        }

        public ValidationRule(ISpecification<TEntity> specification, string errorMessage)
        {
            this.specification = specification;
            ErrorMessage = errorMessage;
            Field = specification.Field ?? "";
        }
    }
}
