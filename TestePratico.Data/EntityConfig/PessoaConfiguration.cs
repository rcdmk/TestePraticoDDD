using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
	public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
	{
		public PessoaConfiguration()
		{
			HasKey(p => p.IdPessoa);

			Property(p => p.Nome)
				.IsRequired()
				.HasMaxLength(150);

			Property(p => p.DDD)
				.HasColumnType("char")
				.HasMaxLength(2);

			Property(p => p.Telefone)
				.HasMaxLength(10);

			Property(p => p.Email)
				.HasMaxLength(150);

			Ignore(p => p.ValidationResult);
			Ignore(p => p.IsValid);
		}
	}
}
