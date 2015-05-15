using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TestePratico.Application;
using TestePratico.Application.Interfaces;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Services;

namespace TestePratico.Commom.Ninject.Modules
{
	public class AppModule : NinjectModule
	{
		public override void Load()
		{
			Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
			Bind<IPessoaAppService>().To<PessoaAppService>();
			Bind<IUFAppService>().To<UFAppService>();

			Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
			Bind<IPessoaService>().To<PessoaService>();
			Bind<IUFService>().To<UFService>();
		}
	}
}
