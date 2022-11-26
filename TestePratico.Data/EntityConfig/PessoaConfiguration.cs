using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
    public class PessoaConfiguration : EntityBaseConfiguration<Person>
    {
        public PessoaConfiguration()
        {

        }

        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.AreaCode)
                .HasMaxLength(2);

            builder.Property(p => p.Phone)
                .HasMaxLength(10);

            builder.Property(p => p.Email)
                .HasMaxLength(150);

            builder.Ignore(p => p.ValidationResult);
            builder.Ignore(p => p.IsValid);
        }
    }
}
