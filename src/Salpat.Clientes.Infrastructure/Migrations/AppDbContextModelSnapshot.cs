﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Salpat.Clientes.Infrastructure.Data;

#nullable disable

namespace Salpat.Clientes.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Salpat.Clientes.Core.ClienteAggregate.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("email");

                    b.Property<int>("Estatus")
                        .HasColumnType("integer")
                        .HasColumnName("estatus");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nombre");

                    b.Property<int>("PuntosGanados")
                        .HasColumnType("integer")
                        .HasColumnName("puntos_ganados");

                    b.Property<int>("PuntosRedimidos")
                        .HasColumnType("integer")
                        .HasColumnName("puntos_redimidos");

                    b.Property<decimal>("SumaImporte")
                        .HasColumnType("numeric")
                        .HasColumnName("suma_importe");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("telefono");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("pk_clientes");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_clientes_email");

                    b.HasIndex("Telefono")
                        .IsUnique()
                        .HasDatabaseName("ix_clientes_telefono");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("Salpat.Clientes.Core.EstacionAggregate.Estacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("Estatus")
                        .HasColumnType("integer")
                        .HasColumnName("estatus");

                    b.Property<decimal>("FactorPuntos")
                        .HasColumnType("numeric")
                        .HasColumnName("factor_puntos");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nombre");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("pk_estaciones");

                    b.ToTable("estaciones", (string)null);
                });

            modelBuilder.Entity("Salpat.Clientes.Core.RecompensaAgreggate.Recompensa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<int>("Estatus")
                        .HasColumnType("integer")
                        .HasColumnName("estatus");

                    b.Property<int>("PuntosRequeridos")
                        .HasColumnType("integer")
                        .HasColumnName("puntos_requeridos");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("pk_recompensas");

                    b.ToTable("recompensas", (string)null);
                });

            modelBuilder.Entity("Salpat.Clientes.Core.TransaccionAggregate.Transaccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("cliente_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("EstacionId")
                        .HasColumnType("integer")
                        .HasColumnName("estacion_id");

                    b.Property<int>("Estatus")
                        .HasColumnType("integer")
                        .HasColumnName("estatus");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha");

                    b.Property<int>("HoseDeliveryId")
                        .HasColumnType("integer")
                        .HasColumnName("hose_delivery_id");

                    b.Property<decimal>("Importe")
                        .HasColumnType("numeric")
                        .HasColumnName("importe");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer")
                        .HasColumnName("producto_id");

                    b.Property<int>("Puntos")
                        .HasColumnType("integer")
                        .HasColumnName("puntos");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.Property<decimal>("Volumen")
                        .HasColumnType("numeric")
                        .HasColumnName("volumen");

                    b.HasKey("Id")
                        .HasName("pk_transacciones");

                    b.HasIndex("ClienteId")
                        .HasDatabaseName("ix_transacciones_cliente_id");

                    b.HasIndex("EstacionId")
                        .HasDatabaseName("ix_transacciones_estacion_id");

                    b.HasIndex("HoseDeliveryId")
                        .IsUnique()
                        .HasDatabaseName("ix_transacciones_hose_delivery_id");

                    b.ToTable("transacciones", (string)null);
                });

            modelBuilder.Entity("Salpat.Clientes.Core.TransaccionAggregate.Transaccion", b =>
                {
                    b.HasOne("Salpat.Clientes.Core.ClienteAggregate.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transacciones_clientes_cliente_id");

                    b.HasOne("Salpat.Clientes.Core.EstacionAggregate.Estacion", null)
                        .WithMany()
                        .HasForeignKey("EstacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transacciones_estaciones_estacion_id");
                });
#pragma warning restore 612, 618
        }
    }
}
