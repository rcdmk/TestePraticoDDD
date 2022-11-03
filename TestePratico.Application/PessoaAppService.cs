using TestePratico.Application.Interfaces;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService servico;

        public PessoaAppService(IPessoaService servico)
            : base(servico)
        {
            this.servico = servico;
        }
    }
}
