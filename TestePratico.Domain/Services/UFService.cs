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
                result.Add("", "This UF can't be deleted because it has people associated with it.");
            }
            else
            {
                result = base.Remove(obj);
            }

            return result;
        }
    }
}
