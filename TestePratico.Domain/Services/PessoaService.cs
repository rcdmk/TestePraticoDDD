using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;

namespace TestePratico.Domain.Services
{
	public class PessoaService : ServiceBase<Pessoa>, IPessoaService
	{
		private IPessoaRepository repository;

		public PessoaService(IPessoaRepository repository)
			:base(repository)
		{
			this.repository = repository;
		}
	}
}
