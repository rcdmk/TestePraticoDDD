using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
