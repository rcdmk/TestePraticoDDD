using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
    public class UFConfiguration : EntityBaseConfiguration<UF>
    {
        public override void Configure(EntityTypeBuilder<UF> builder)
        {
            base.Configure(builder);

            builder.ToTable("UFs");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Ignore(u => u.ValidationResult);
            builder.Ignore(u => u.IsValid);

            builder.HasData(new[]{
                new UF(UFId: 1, nome: "SP")
            });
        }
    }
}
