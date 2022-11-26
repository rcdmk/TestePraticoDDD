using Microsoft.EntityFrameworkCore;
using TestePratico.Data.EntityConfig;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.Context
{
    public class TestePraticoContext : DbContext
    {
        public DbSet<Person> Pessoas { get; set; } = null!;
        public DbSet<UF> UF { get; set; } = null!;

        protected TestePraticoContext()
        {
        }

        public TestePraticoContext(DbContextOptions<TestePraticoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new UFConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(50);
        }
    }
}
