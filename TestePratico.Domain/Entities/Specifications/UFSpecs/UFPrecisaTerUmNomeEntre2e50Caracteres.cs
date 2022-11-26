using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Entities.Specifications.UFSpecs
{
    public class UFPrecisaTerUmNomeEntre2e50Caracteres : ISpecification<UF>
    {
        public string Field => nameof(UF.Name);

        public bool IsSatisfiedBy(UF entity)
        {
            return entity.Name.Length >= 2 && entity.Name.Length <= 50;
        }
    }
}
