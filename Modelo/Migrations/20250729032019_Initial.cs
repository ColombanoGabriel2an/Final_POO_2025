using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modelo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    DescuentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "TEXT", nullable: false),
                    MontoMinimo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Acumulable = table.Column<bool>(type: "INTEGER", nullable: false),
                    MontoFijo = table.Column<decimal>(type: "TEXT", nullable: false),
                    TopeReintegro = table.Column<decimal>(type: "TEXT", nullable: false),
                    Banco = table.Column<string>(type: "TEXT", nullable: false),
                    Emisor = table.Column<string>(type: "TEXT", nullable: false),
                    Rubro = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.DescuentoId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Banco = table.Column<string>(type: "TEXT", nullable: false),
                    EntidadEmisora = table.Column<string>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: false),
                    TipoTarjeta = table.Column<string>(type: "TEXT", nullable: false),
                    Limite = table.Column<decimal>(type: "TEXT", nullable: true),
                    Disponible = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsExtension = table.Column<bool>(type: "INTEGER", nullable: true),
                    TenedorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Personas_TenedorId",
                        column: x => x.TenedorId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acreditaciones",
                columns: table => new
                {
                    AcreditacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    MedioDePago = table.Column<string>(type: "TEXT", nullable: false),
                    TarjetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TarjetaCreditoTarjetaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acreditaciones", x => x.AcreditacionId);
                    table.ForeignKey(
                        name: "FK_Acreditaciones_Tarjetas_TarjetaCreditoTarjetaId",
                        column: x => x.TarjetaCreditoTarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId");
                    table.ForeignKey(
                        name: "FK_Acreditaciones_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    ConsumoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Hora = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Moneda = table.Column<string>(type: "TEXT", nullable: false),
                    Rubro = table.Column<string>(type: "TEXT", nullable: true),
                    Comercio = table.Column<string>(type: "TEXT", nullable: true),
                    EsRecurrente = table.Column<bool>(type: "INTEGER", nullable: true),
                    TarjetaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TarjetaCreditoTarjetaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.ConsumoId);
                    table.ForeignKey(
                        name: "FK_Consumos_Tarjetas_TarjetaCreditoTarjetaId",
                        column: x => x.TarjetaCreditoTarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId");
                    table.ForeignKey(
                        name: "FK_Consumos_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumoDescuento",
                columns: table => new
                {
                    ConsumoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DescuentosAplicadosDescuentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDescuento", x => new { x.ConsumoId, x.DescuentosAplicadosDescuentoId });
                    table.ForeignKey(
                        name: "FK_ConsumoDescuento_Consumos_ConsumoId",
                        column: x => x.ConsumoId,
                        principalTable: "Consumos",
                        principalColumn: "ConsumoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumoDescuento_Descuentos_DescuentosAplicadosDescuentoId",
                        column: x => x.DescuentosAplicadosDescuentoId,
                        principalTable: "Descuentos",
                        principalColumn: "DescuentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Descuentos",
                columns: new[] { "DescuentoId", "Activo", "Acumulable", "Banco", "Codigo", "Descripcion", "Emisor", "FechaFin", "FechaInicio", "MontoFijo", "MontoMinimo", "Nombre", "Porcentaje", "Rubro", "Tipo", "TopeReintegro" },
                values: new object[,]
                {
                    { 1, true, false, "Banco Santander", "SUPER30", "30% los miércoles en supermercados", "VISA", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Miércoles de descuentos", 30m, "Supermercados", "Porcentual", 3000m },
                    { 2, true, false, "Banco BBVA", "REST2X1", "2x1 en restaurantes adheridos", "American Express", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "2x1 en Restaurantes", 50m, "Restaurantes", "Porcentual", 1500m },
                    { 3, true, true, "Banco Nación", "FARM15", "15% todos los días en farmacias", "Mastercard", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Descuento en Farmacias", 15m, "Farmacias", "Porcentual", 1000m },
                    { 4, true, false, "Banco BBVA", "FARM500", "$500 de descuento en compras superiores a $3000", "VISA", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 0m, "Reintegro en Farmacias", 0m, "Farmacias", "Monto Fijo", 3000m },
                    { 5, true, true, "Banco Santander", "TECH12C", "12 cuotas sin interés en tecnología", "VISA", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "12 Cuotas Tecnología", 0m, "Electrónica", "Financiación", 10000m },
                    { 6, true, false, "Banco BBVA", "TECH20", "20% en artículos seleccionados de tecnología", "Mastercard", new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Descuento en Tecnología", 20m, "Electrónica", "Porcentual", 5000m },
                    { 7, true, false, "Banco Macro", "ROPA30FDS", "30% en ropa los fines de semana", "VISA", new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Fines de Semana de Moda", 30m, "Indumentaria", "Porcentual", 4000m },
                    { 8, true, true, "Banco Macro", "ROPA3C10", "3 cuotas sin interés + 10% off", "Mastercard", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2000m, "Cuotas + Descuento", 10m, "Indumentaria", "Mixto", 5000m },
                    { 9, true, true, "Banco BBVA", "ROPA6C20", "6 cuotas sin interés + 20% off", "Mastercard", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2000m, "Cuotas + Descuento", 20m, "Indumentaria", "Mixto", 5000m }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaId", "Apellido", "DNI", "Nombre" },
                values: new object[,]
                {
                    { 1, "Colombano", "44555998", "Gabriel" },
                    { 2, "Llanos", "12355666", "Matias" },
                    { 3, "Gallegos", "12577889", "Laureano" },
                    { 4, "Lopez", "13344895", "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "TarjetaId", "Alias", "Banco", "EntidadEmisora", "FechaVencimiento", "Numero", "PersonaId", "Saldo", "TipoTarjeta" },
                values: new object[] { 1, "BBVA Mati", "Banco BBVA", "VISA", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "1111222233334444", 2, 100000m, "Debito" });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "TarjetaId", "Alias", "Banco", "Disponible", "EntidadEmisora", "FechaVencimiento", "IsExtension", "Limite", "Numero", "PersonaId", "TenedorId", "TipoTarjeta" },
                values: new object[,]
                {
                    { 2, "Macro Mati", "Banco Macro", 500000m, "Mastercard", new DateTime(2028, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1000000m, "5555666677778888", 2, 2, "Credito" },
                    { 3, "VISA Gabi", "Banco Santander", 1200000m, "VISA", new DateTime(2027, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1500000m, "1234123412341234", 1, 1, "Credito" }
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "TarjetaId", "Alias", "Banco", "EntidadEmisora", "FechaVencimiento", "Numero", "PersonaId", "Saldo", "TipoTarjeta" },
                values: new object[] { 4, "Naranja Pedro", "Banco BBVA", "Mastercard", new DateTime(2030, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "5678567856785678", 4, 200000m, "Debito" });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "TarjetaId", "Alias", "Banco", "Disponible", "EntidadEmisora", "FechaVencimiento", "IsExtension", "Limite", "Numero", "PersonaId", "TenedorId", "TipoTarjeta" },
                values: new object[] { 5, "BBVA MC Mati", "Banco BBVA", 500000m, "Mastercard", new DateTime(2028, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1000000m, "5555666677778888", 2, 2, "Credito" });

            migrationBuilder.InsertData(
                table: "Consumos",
                columns: new[] { "ConsumoId", "Comercio", "Descripcion", "EsRecurrente", "Fecha", "Hora", "Moneda", "Monto", "Rubro", "TarjetaCreditoTarjetaId", "TarjetaId" },
                values: new object[,]
                {
                    { 1, "Star Computacion", "Compra en tienda de tecnología", false, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "12:30", "ARG", 300m, "Electrónica", null, 1 },
                    { 2, "Sport 78", "Compra en tienda de ropa", false, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "14:00", "ARG", 500m, "Ropa", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_TarjetaCreditoTarjetaId",
                table: "Acreditaciones",
                column: "TarjetaCreditoTarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Acreditaciones_TarjetaId",
                table: "Acreditaciones",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoDescuento_DescuentosAplicadosDescuentoId",
                table: "ConsumoDescuento",
                column: "DescuentosAplicadosDescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_TarjetaCreditoTarjetaId",
                table: "Consumos",
                column: "TarjetaCreditoTarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_TarjetaId",
                table: "Consumos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_PersonaId",
                table: "Tarjetas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_TenedorId",
                table: "Tarjetas",
                column: "TenedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acreditaciones");

            migrationBuilder.DropTable(
                name: "ConsumoDescuento");

            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
