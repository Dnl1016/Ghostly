﻿// <auto-generated />
using System;
using Ghostly.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ghostly.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210615150911_CompleteDB3")]
    partial class CompleteDB3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ghostly.Web.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Cellphone")
                        .HasMaxLength(20);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.ImageProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int?>("ProductoId");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("imageProductos");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Precio");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Talla")
                        .IsRequired();

                    b.Property<int?>("TipoProductoId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TipoProductoId");

                    b.HasIndex("UserId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("TipoProductos");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Cellphone")
                        .HasMaxLength(20);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientesId");

                    b.Property<string>("Comentario");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Estado");

                    b.Property<int?>("ProductosId");

                    b.Property<int?>("UserId");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("ProductosId");

                    b.HasIndex("UserId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.ImageProducto", b =>
                {
                    b.HasOne("Ghostly.Web.Data.Entities.Producto", "Producto")
                        .WithMany("ImageProductos")
                        .HasForeignKey("ProductoId");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.Producto", b =>
                {
                    b.HasOne("Ghostly.Web.Data.Entities.TipoProducto", "TipoProducto")
                        .WithMany("Productos")
                        .HasForeignKey("TipoProductoId");

                    b.HasOne("Ghostly.Web.Data.Entities.User", "User")
                        .WithMany("Productos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Ghostly.Web.Data.Entities.Venta", b =>
                {
                    b.HasOne("Ghostly.Web.Data.Entities.Cliente", "Clientes")
                        .WithMany("Ventas")
                        .HasForeignKey("ClientesId");

                    b.HasOne("Ghostly.Web.Data.Entities.Producto", "Productos")
                        .WithMany("Ventas")
                        .HasForeignKey("ProductosId");

                    b.HasOne("Ghostly.Web.Data.Entities.User", "User")
                        .WithMany("Ventas")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
