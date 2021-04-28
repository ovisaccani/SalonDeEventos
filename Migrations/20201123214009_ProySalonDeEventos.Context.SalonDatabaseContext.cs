using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProySalonDeEventos.Migrations
{
    public partial class ProySalonDeEventosContextSalonDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    cuit = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    pass = table.Column<string>(nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    musica = table.Column<string>(nullable: true),
                    decoracion = table.Column<string>(nullable: true),
                    catering = table.Column<string>(nullable: true),
                    tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    IdPresupuesto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCliente = table.Column<string>(nullable: true),
                    cantInvitados = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    mail = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.IdPresupuesto);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantInvitados = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    CurrentIdEvento = table.Column<int>(nullable: false),
                    CurrentIdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_CurrentIdCliente",
                        column: x => x.CurrentIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Eventos_CurrentIdEvento",
                        column: x => x.CurrentIdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CurrentIdCliente",
                table: "Reservas",
                column: "CurrentIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CurrentIdEvento",
                table: "Reservas",
                column: "CurrentIdEvento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
