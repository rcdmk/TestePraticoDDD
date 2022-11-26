using TestePratico.Application.Interfaces;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Application
{
    public class PessoaAppService : AppServiceBase<Person>, IPessoaAppService
    {
        private readonly IPersonService servico;

        public PessoaAppService(IPersonService servico)
            : base(servico)
        {
            this.servico = servico;
        }
    }
}
