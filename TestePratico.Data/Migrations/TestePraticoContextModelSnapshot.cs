﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestePratico.Data.Context;

#nullable disable

namespace TestePratico.Data.Migrations
{
    [DbContext(typeof(TestePraticoContext))]
    partial class TestePraticoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TestePratico.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<DateOnly?>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("UFId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP");

                    b.HasKey("PessoaId");

                    b.HasIndex("UFId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.UF", b =>
                {
                    b.Property<int>("UFId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TIMESTAMP");

                    b.HasKey("UFId");

                    b.ToTable("UFs", (string)null);

                    b.HasData(
                        new
                        {
                            UFId = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "SP",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.Pessoa", b =>
                {
                    b.HasOne("TestePratico.Domain.Entities.UF", "UF")
                        .WithMany("Pessoas")
                        .HasForeignKey("UFId");

                    b.Navigation("UF");
                });

            modelBuilder.Entity("TestePratico.Domain.Entities.UF", b =>
                {
                    b.Navigation("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
