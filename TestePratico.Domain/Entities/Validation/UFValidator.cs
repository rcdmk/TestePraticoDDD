using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities.Specifications.UFSpecs;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities.Validation
{
    public class UFValidator : Validator<UF>
    {
        public UFValidator()
        {
            AddRule(new ValidationRule<UF>(new UFPrecisaTerUmNomeDefinidoSpec(), "It's required to provide a name"));
            AddRule(new ValidationRule<UF>(new UFPrecisaTerUmNomeEntre2e50Caracteres(), "Name must be between 2 and 50 characters long"));
        }
    }
}
