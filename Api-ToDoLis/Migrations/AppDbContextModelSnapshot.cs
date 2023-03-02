﻿// <auto-generated />
using System;
using Api_ToDoLis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_ToDoLis.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Api_ToDoLis.Models.TipoLista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao_tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoListas");
                });

            modelBuilder.Entity("Api_ToDoLis.Models.ToDoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Concluido")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Tipo_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Tipo_Id")
                        .IsUnique();

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("Api_ToDoLis.Models.ToDoList", b =>
                {
                    b.HasOne("Api_ToDoLis.Models.TipoLista", "TipoLista")
                        .WithOne("ToDoList")
                        .HasForeignKey("Api_ToDoLis.Models.ToDoList", "Tipo_Id");

                    b.Navigation("TipoLista");
                });

            modelBuilder.Entity("Api_ToDoLis.Models.TipoLista", b =>
                {
                    b.Navigation("ToDoList")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}