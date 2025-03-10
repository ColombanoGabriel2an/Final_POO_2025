using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    DescuentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoFijo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TopeMonto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rubro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.DescuentoId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadEmisora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Disponible = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsExtension = table.Column<bool>(type: "bit", nullable: true),
                    TenedorPersonaId = table.Column<int>(type: "int", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    AcreditacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedioDePago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    TarjetaCreditoTarjetaId = table.Column<int>(type: "int", nullable: true)
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
                    ConsumoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    TarjetaCreditoTarjetaId = table.Column<int>(type: "int", nullable: true)
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
                    ConsumoId = table.Column<int>(type: "int", nullable: false),
                    DescuentosAplicadosDescuentoId = table.Column<int>(type: "int", nullable: false)
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
