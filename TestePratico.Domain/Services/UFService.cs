using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Services
{
    public class UFService : ServiceBase<UF>, IUFService
    {
        private IUFRepository repository;

        public UFService(IUFRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public override ValidationResult Remove(UF obj)
        {
            ValidationResult result;

            if (obj.People.Count > 0 || obj.PeopleCount > 0)
            {
                result = new ValidationResult();
                result.Add("", "Esta UF não pode ser excluída porque tem pessoas associadas a ela.");
            }
            else
            {
                result = base.Remove(obj);
            }

            return result;
        }
    }
}
