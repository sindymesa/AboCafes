﻿// <auto-generated />
using System;
using AboCafes.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AboCafes.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210304224145_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AboCafes.Common.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartamentoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Corregimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CiudadId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Corregimientos");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Finca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(40);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Telefono")
                        .HasMaxLength(20);

                    b.Property<int?>("TerceroId");

                    b.Property<int?>("VeredaId");

                    b.HasKey("Id");

                    b.HasIndex("TerceroId");

                    b.HasIndex("VeredaId");

                    b.ToTable("Fincas");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Hectarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Arrobas");

                    b.Property<int>("CantidadKF");

                    b.Property<int>("CantidadKN");

                    b.Property<int>("CantidadKP");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int?>("LoteId");

                    b.Property<int>("Menores");

                    b.Property<int>("Palos");

                    b.Property<decimal>("Ph");

                    b.Property<DateTime>("Siembra");

                    b.HasKey("Id");

                    b.HasIndex("LoteId");

                    b.ToTable("Hectareas");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FincaId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("FincaId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Parafertil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadKF");

                    b.Property<int>("CantidadKN");

                    b.Property<int>("CantidadKP");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Menores");

                    b.Property<int>("Meses");

                    b.Property<int>("PalosDesde");

                    b.Property<int>("PalosHasta");

                    b.Property<int>("PhHasta");

                    b.Property<int>("Phdesde");

                    b.HasKey("Id");

                    b.ToTable("Parafertils");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadKF");

                    b.Property<int>("CantidadKN");

                    b.Property<int>("CantidadKP");

                    b.Property<string>("Detalle")
                        .HasMaxLength(100);

                    b.Property<int>("Menores");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Tercero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CiudadId");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Telefono")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.ToTable("Tercero");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Vereda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CorregimientoId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CorregimientoId");

                    b.ToTable("Veredas");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Ciudad", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("DepartamentoId");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Corregimiento", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Ciudad")
                        .WithMany("Corregimientos")
                        .HasForeignKey("CiudadId");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Finca", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Tercero")
                        .WithMany("Fincas")
                        .HasForeignKey("TerceroId");

                    b.HasOne("AboCafes.Common.Entities.Vereda")
                        .WithMany("Finca")
                        .HasForeignKey("VeredaId");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Hectarea", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Lote", "Lote")
                        .WithMany("Hectareas")
                        .HasForeignKey("LoteId");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Lote", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Finca")
                        .WithMany("Lotes")
                        .HasForeignKey("FincaId");
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Tercero", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AboCafes.Common.Entities.Vereda", b =>
                {
                    b.HasOne("AboCafes.Common.Entities.Corregimiento")
                        .WithMany("Veredas")
                        .HasForeignKey("CorregimientoId");
                });
#pragma warning restore 612, 618
        }
    }
}
