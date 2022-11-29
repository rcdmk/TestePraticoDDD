using TestePratico.Application.Interfaces;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Application
{
    public class PersonAppService : AppServiceBase<Person>, IPersonAppService
    {
        private readonly IPersonService service;

        public PersonAppService(IPersonService service)
            : base(service)
        {
            this.service = service;
        }
    }
}
