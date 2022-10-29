using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Application.Interfaces;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Validation;

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

        public IEnumerable<UF> GetAll()
        {
            return servico.GetAll();
        }
    }
}
