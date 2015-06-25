using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Services.Interfaces;

namespace TestePratico.Services
{
	public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
	{
		public PessoaAppService(IPessoaService domainservice)
			:base(domainservice)
		{
			this.domainService = domainservice;
		}
	}
}
