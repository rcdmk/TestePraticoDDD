using TestePratico.Application.Interfaces;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Application
{
    public class UFAppService : AppServiceBase<UF>, IUFAppService
    {
        private readonly IUFService servico;

        public UFAppService(IUFService servico)
            : base(servico)
        {
            this.servico = servico;
        }
    }
}
