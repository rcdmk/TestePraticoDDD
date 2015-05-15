using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
	public class UFConfiguration : EntityTypeConfiguration<UF>
	{
		public UFConfiguration()
		{
			HasKey(u => u.IdUF);

			Property(u => u.Nome)
				.IsRequired()
				.HasMaxLength(50);

			Ignore(u => u.ValidationResult);
			Ignore(u => u.IsValid);
		}
	}
}
