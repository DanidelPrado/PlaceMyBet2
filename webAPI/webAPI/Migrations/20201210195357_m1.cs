using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webAPI.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    Visitante = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cuota_Over = table.Column<double>(nullable: false),
                    Cuota_Under = table.Column<double>(nullable: false),
                    Dinero_Over = table.Column<double>(nullable: false),
                    Dinero_Under = table.Column<double>(nullable: false),
                    Tipo_Mercado = table.Column<double>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo_Mercado = table.Column<double>(nullable: false),
                    Cuota = table.Column<double>(nullable: false),
                    Dinero = table.Column<double>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    Id_Mercado = table.Column<int>(nullable: false),
                    Tipo_Cuota = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true),
                    EventoId = table.Column<int>(nullable: false),
                    MercadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Fecha", "Local", "Visitante" },
                values: new object[,]
                {
                    { 1, "2020-10-17", "Valencia", "Espanyol" },
                    { 2, "2020-10-30", "Barcelona", "Valladolid" },
                    { 3, "2020 -10-23", "Madrid", "Villareal" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Edad", "Nombre" },
                values: new object[,]
                {
                    { "AnaRS@gmail.com", "Rodríguez Sánchez", 25, "Ana" },
                    { "JuanPL@gmail.com", "Pérez López", 27, "Juan" },
                    { "PepeGB@gmail.com", "Gómez Botella", 23, "Pepe" }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero", "EventoId", "Fecha", "Id_Mercado", "MercadoId", "Tipo_Cuota", "Tipo_Mercado", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1.8700000000000001, 200.0, 0, "2020-10-14", 1, null, "over", 1.5, "AnaRS@gmail.com" },
                    { 2, 2.3900000000000001, 150.0, 0, "2020-09-15", 2, null, "under", 2.5, "JuanPL@gmail.com" },
                    { 3, 1.9199999999999999, 175.0, 0, "2020-09-16", 3, null, "over", 3.5, "PepeGB@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "Cuota_Over", "Cuota_Under", "Dinero_Over", "Dinero_Under", "EventoId", "Tipo_Mercado" },
                values: new object[,]
                {
                    { 1, 1.4299999999999999, 2.8500000000000001, 100.0, 50.0, 1, 1.5 },
                    { 2, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 2, 2.5 },
                    { 3, 2.8500000000000001, 1.4299999999999999, 50.0, 100.0, 3, 3.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoId",
                table: "Apuestas",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoId",
                table: "Mercados",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
