using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Services.Interfaces;

namespace TestePratico.Services
{
	public class UFAppService : AppServiceBase<UF>, IUFAppService
	{
		public UFAppService(IUFService domainservice)
			:base(domainservice)
		{
			this.domainService = domainservice;
		}
	}
}
