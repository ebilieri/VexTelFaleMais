﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VexTel.Repository.Context;

namespace VexTel.Repository.Migrations
{
    [DbContext(typeof(VexTelContext))]
    [Migration("20200202031051_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VexTel.Domain.Entities.CustoChamada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CustoMinuto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("DDDDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("DDDOrigemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DDDDestinoId");

                    b.HasIndex("DDDOrigemId");

                    b.ToTable("CustoChamadas");
                });

            modelBuilder.Entity("VexTel.Domain.Entities.DDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(3) CHARACTER SET utf8mb4")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("DDDs");
                });

            modelBuilder.Entity("VexTel.Domain.Entities.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<int>("TempoMinutos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("VexTel.Domain.Entities.CustoChamada", b =>
                {
                    b.HasOne("VexTel.Domain.Entities.DDD", "DDDDestino")
                        .WithMany()
                        .HasForeignKey("DDDDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VexTel.Domain.Entities.DDD", "DDDOrigem")
                        .WithMany()
                        .HasForeignKey("DDDOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
