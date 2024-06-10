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

            modelBuilder.Entity("Salpat.Clientes.Core.ContributorAggregate.Contributor", b =>
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Usuario")
                        .HasColumnType("text")
                        .HasColumnName("usuario");

                    b.HasKey("Id")
                        .HasName("pk_contributors");

                    b.ToTable("contributors", (string)null);
                });

            modelBuilder.Entity("Salpat.Clientes.Core.ContributorAggregate.Contributor", b =>
                {
                    b.OwnsOne("Salpat.Clientes.Core.ContributorAggregate.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("ContributorId")
                                .HasColumnType("integer")
                                .HasColumnName("id");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("phone_number_country_code");

                            b1.Property<string>("Extension")
                                .HasColumnType("text")
                                .HasColumnName("phone_number_extension");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("phone_number_number");

                            b1.HasKey("ContributorId");

                            b1.ToTable("contributors");

                            b1.WithOwner()
                                .HasForeignKey("ContributorId")
                                .HasConstraintName("fk_contributors_contributors_id");
                        });

                    b.Navigation("PhoneNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
