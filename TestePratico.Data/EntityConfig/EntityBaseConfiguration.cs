using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestePratico.Domain.Entities;

namespace TestePratico.Data.EntityConfig
{
    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase<TEntity>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var metadata = builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();

            metadata = builder.Property(p => p.UpdatedAt)
                .IsRequired()
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
