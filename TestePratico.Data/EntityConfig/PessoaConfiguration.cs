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
    public class PessoaConfiguration : EntityBaseConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {

        }

        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.DDD)
                .HasMaxLength(2);

            builder.Property(p => p.Telefone)
                .HasMaxLength(10);

            builder.Property(p => p.Email)
                .HasMaxLength(150);

            builder.Ignore(p => p.ValidationResult);
            builder.Ignore(p => p.IsValid);
        }
    }
}
