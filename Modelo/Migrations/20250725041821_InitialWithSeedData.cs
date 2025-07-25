using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Modelo.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeedData : Migration
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
                    TenedorPersonaId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_Tarjetas_Personas_TenedorPersonaId",
                        column: x => x.TenedorPersonaId,
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
                    Rubro = table.Column<string>(type: "TEXT", nullable: false),
                    Comercio = table.Column<string>(type: "TEXT", nullable: false),
                    EsRecurrente = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    { 1, true, true, "Todos", "DESC10", "Descuento del 10% en compras", "Sistema", new DateTime(2025, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 100m, "Descuento 10%", 10m, "Todos", "Porcentual", 1000m },
                    { 2, true, false, "Banco Nación", "DESC20", "Descuento del 20% en compras", "Sistema", new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 500m, "Descuento 20%", 20m, "Alimentación", "Porcentual", 2000m },
                    { 3, true, true, "Todos", "DESC5", "Descuento del 5% en compras", "Sistema", new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 50m, "Descuento 5%", 5m, "Todos", "Porcentual", 500m }
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
                name: "IX_Tarjetas_TenedorPersonaId",
                table: "Tarjetas",
                column: "TenedorPersonaId");
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
