using Microsoft.EntityFrameworkCore.Migrations;

namespace webAPI.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero", "Fecha", "Id_Mercado", "Id_Usuario", "MercadoId", "Tipo_Cuota", "Tipo_Mercado", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1.8700000000000001, 200.0, "2020-10-14", 1, "AnaRS@gmail.com", null, "over", 1.5, null },
                    { 2, 2.3900000000000001, 150.0, "2020-09-15", 2, "JuanPL@gmail.com", null, "under", 2.5, null },
                    { 3, 1.9199999999999999, 175.0, "2020-09-16", 3, "PepeGB@gmail.com", null, "over", 3.5, null }
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
                table: "Mercados",
                columns: new[] { "MercadoId", "Cuota_Over", "Cuota_Under", "Dinero_Over", "Dinero_Under", "EventoId", "Id_Evento", "Tipo_Mercado" },
                values: new object[,]
                {
                    { 1, 1.4299999999999999, 2.8500000000000001, 100.0, 50.0, null, 1, 1.5 },
                    { 2, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, null, 2, 2.5 },
                    { 3, 2.8500000000000001, 1.4299999999999999, 50.0, 100.0, null, 3, 3.5 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "AnaRS@gmail.com");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "JuanPL@gmail.com");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "PepeGB@gmail.com");
        }
    }
}
