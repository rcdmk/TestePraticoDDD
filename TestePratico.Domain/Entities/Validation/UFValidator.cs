﻿using System;
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
            AddRule(new ValidationRule<UF>(new UFPrecisaTerUmNomeDefinidoSpec(), "É obrigatório informar um nome"));
            AddRule(new ValidationRule<UF>(new UFPrecisaTerUmNomeEntre2e50Caracteres(), "O nome precisa ter entre 2 e 50 caracteres"));
        }
    }
}
