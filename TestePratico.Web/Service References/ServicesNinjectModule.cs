using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TestePratico.Web.WCF.PessoaAppService;
using TestePratico.Web.WCF.UFAppService;

namespace TestePratico.Commom.Ninject.Modules
{
	public class ServicesNinjectModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IAppServiceBaseOf_Pessoa>().To<AppServiceBaseOf_PessoaClient>();
			Bind<IAppServiceBaseOf_UF>().To<AppServiceBaseOf_UFClient>();
		}
	}
}
