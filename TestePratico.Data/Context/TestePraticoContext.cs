﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TestePratico.Data.EntityConfig;
using TestePratico.Domain.Entities;
using Microsoft.Extensions.Configuration;
using TestePratico.Domain.Validation;

namespace TestePratico.Data.Context
{
    public class TestePraticoContext : DbContext
    {
        protected TestePraticoContext()
        {
        }

        public TestePraticoContext(DbContextOptions<TestePraticoContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<UF> UF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

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
