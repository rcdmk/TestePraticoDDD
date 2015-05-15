using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TestePratico.Data.Repositories;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Commom.Ninject.Modules
{
	public class DataModule : NinjectModule
	{
		public override void Load()
		{
			Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
			Bind<IPessoaRepository>().To<PessoaRepository>();
			Bind<IUFRepository>().To<UFRepository>();
		}
	}
}
