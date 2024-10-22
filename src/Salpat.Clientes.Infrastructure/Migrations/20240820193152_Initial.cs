using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Salpat.Clientes.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class Initial : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "configuraciones",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  mail_host = table.Column<string>(type: "text", nullable: false),
                  mail_port = table.Column<string>(type: "text", nullable: false),
                  mail_username = table.Column<string>(type: "text", nullable: false),
                  mail_password = table.Column<string>(type: "text", nullable: false),
                  mail_address = table.Column<string>(type: "text", nullable: false),
                  tiempo_minimo_entre_cargas = table.Column<int>(type: "integer", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_configuraciones", x => x.id);
              });

          migrationBuilder.CreateTable(
              name: "empresas",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  nombre = table.Column<string>(type: "text", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_empresas", x => x.id);
              });

          migrationBuilder.CreateTable(
              name: "estaciones",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  nombre = table.Column<string>(type: "text", nullable: false),
                  factor_puntos = table.Column<decimal>(type: "numeric", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_estaciones", x => x.id);
              });

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

          migrationBuilder.CreateTable(
              name: "redenciones",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  cliente_id = table.Column<int>(type: "integer", nullable: false),
                  fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  recompensa_id = table.Column<int>(type: "integer", nullable: false),
                  puntos_redimidos = table.Column<int>(type: "integer", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_redenciones", x => x.id);
              });

          migrationBuilder.CreateTable(
              name: "clientes",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                  telefono = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                  email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                  suma_importe = table.Column<decimal>(type: "numeric", nullable: false),
                  puntos_ganados = table.Column<int>(type: "integer", nullable: false),
                  puntos_redimidos = table.Column<int>(type: "integer", nullable: false),
                  empresa_id = table.Column<int>(type: "integer", nullable: true),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_clientes", x => x.id);
                  table.ForeignKey(
                      name: "fk_clientes_empresas_empresa_id",
                      column: x => x.empresa_id,
                      principalTable: "empresas",
                      principalColumn: "id");
              });

          migrationBuilder.CreateTable(
              name: "transacciones",
              columns: table => new
              {
                  id = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  hose_delivery_id = table.Column<int>(type: "integer", nullable: false),
                  fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  importe = table.Column<decimal>(type: "numeric", nullable: false),
                  volumen = table.Column<decimal>(type: "numeric", nullable: false),
                  producto_id = table.Column<int>(type: "integer", nullable: false),
                  puntos = table.Column<int>(type: "integer", nullable: false),
                  cliente_id = table.Column<int>(type: "integer", nullable: false),
                  estacion_id = table.Column<int>(type: "integer", nullable: false),
                  posicion = table.Column<int>(type: "integer", nullable: false),
                  usuario = table.Column<string>(type: "text", nullable: true),
                  estatus = table.Column<int>(type: "integer", nullable: false),
                  created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("pk_transacciones", x => x.id);
                  table.ForeignKey(
                      name: "fk_transacciones_clientes_cliente_id",
                      column: x => x.cliente_id,
                      principalTable: "clientes",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Cascade);
                  table.ForeignKey(
                      name: "fk_transacciones_estaciones_estacion_id",
                      column: x => x.estacion_id,
                      principalTable: "estaciones",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateIndex(
              name: "ix_clientes_email",
              table: "clientes",
              column: "email",
              unique: true);

          migrationBuilder.CreateIndex(
              name: "ix_clientes_empresa_id",
              table: "clientes",
              column: "empresa_id");

          migrationBuilder.CreateIndex(
              name: "ix_clientes_telefono",
              table: "clientes",
              column: "telefono",
              unique: true);

          migrationBuilder.CreateIndex(
              name: "ix_transacciones_cliente_id",
              table: "transacciones",
              column: "cliente_id");

          migrationBuilder.CreateIndex(
              name: "ix_transacciones_estacion_id_hose_delivery_id",
              table: "transacciones",
              columns: new[] { "estacion_id", "hose_delivery_id" },
              unique: true);
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "configuraciones");

          migrationBuilder.DropTable(
              name: "recompensas");

          migrationBuilder.DropTable(
              name: "redenciones");

          migrationBuilder.DropTable(
              name: "transacciones");

          migrationBuilder.DropTable(
              name: "clientes");

          migrationBuilder.DropTable(
              name: "estaciones");

          migrationBuilder.DropTable(
              name: "empresas");
      }
  }
