using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Data.EntityConfig;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Validation;

namespace TestePratico.Data.Context
{
	public class TestePraticoContext : DbContext
	{
		public TestePraticoContext()
			:base("TestePraticoDB")
		{

		}

		public DbSet<Pessoa> Pessoas { get; set; }
		public DbSet<UF> UF { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties()
				.Where(p => p.Name == "Id" + p.ReflectedType.Name)
				.Configure(p => p.IsKey());

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(50));

			modelBuilder.Configurations.Add(new PessoaConfiguration());
			modelBuilder.Configurations.Add(new UFConfiguration());
		}
	}
}
