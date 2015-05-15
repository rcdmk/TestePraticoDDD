using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TestePratico.Commom.Ninject.Modules;

namespace TestePratico.Commom.Ninject
{
	public class ModuleHelper
	{
		private ModuleHelper()
		{
			throw new InvalidOperationException("Não é permitido instanciar esta classe.");
		}

		public static IList<INinjectModule> GetModules()
		{
			return new List<INinjectModule>()
			{
				new DataModule(),
				new AppModule()
			};
		}
	}
}
