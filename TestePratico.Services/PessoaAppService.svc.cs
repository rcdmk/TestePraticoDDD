using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Services.Interfaces;

namespace TestePratico.Services
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        public PessoaAppService(IPessoaService domainservice)
            : base(domainservice)
        {
            this.domainService = domainservice;
        }
    }
}
