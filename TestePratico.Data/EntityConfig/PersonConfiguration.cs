using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
    public class PersonConfiguration : EntityBaseConfiguration<Person>
    {
        public PersonConfiguration()
        {
        }

        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.ToTable("People");

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
