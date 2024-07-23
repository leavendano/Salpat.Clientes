using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Salpat.Clientes.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class AddVolume : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AddColumn<int>(
              name: "producto_id",
              table: "transacciones",
              type: "integer",
              nullable: false,
              defaultValue: 0);

          migrationBuilder.AddColumn<decimal>(
              name: "volumen",
              table: "transacciones",
              type: "numeric",
              nullable: false,
              defaultValue: 0m);

          migrationBuilder.AddColumn<decimal>(
              name: "factor_puntos",
              table: "estaciones",
              type: "numeric",
              nullable: false,
              defaultValue: 0m);

          migrationBuilder.CreateTable(
              name: "recompensas",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  descripcion = table.Column<string>(type: "text", nullable: false),
                  puntos_requeridos = table.Column<int>(type: "integer", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_recompensas", x => x.id);
              });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "recompensas");

          migrationBuilder.DropColumn(
              name: "producto_id",
              table: "transacciones");

          migrationBuilder.DropColumn(
              name: "volumen",
              table: "transacciones");

          migrationBuilder.DropColumn(
              name: "factor_puntos",
              table: "estaciones");
      }
  }
