using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Domain.Services
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        private IPersonRepository repository;

        public PersonService(IPersonRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
