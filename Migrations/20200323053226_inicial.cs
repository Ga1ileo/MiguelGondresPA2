using Microsoft.EntityFrameworkCore.Migrations;

namespace MiguelGondresPA2.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llamadas",
                columns: table => new
                {
                    LlamadaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamadas", x => x.LlamadaId);
                });

            migrationBuilder.CreateTable(
                name: "LlamadaDetalle",
                columns: table => new
                {
                    LlamadaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LlamadaId = table.Column<int>(nullable: false),
                    Problema = table.Column<string>(nullable: true),
                    Solucion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadaDetalle", x => x.LlamadaDetalleId);
                    table.ForeignKey(
                        name: "FK_LlamadaDetalle_Llamadas_LlamadaId",
                        column: x => x.LlamadaId,
                        principalTable: "Llamadas",
                        principalColumn: "LlamadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Llamadas",
                columns: new[] { "LlamadaId", "Descripcion" },
                values: new object[] { 1, "Guitarra" });

            migrationBuilder.InsertData(
                table: "Llamadas",
                columns: new[] { "LlamadaId", "Descripcion" },
                values: new object[] { 2, "Celular" });

            migrationBuilder.InsertData(
                table: "LlamadaDetalle",
                columns: new[] { "LlamadaDetalleId", "LlamadaId", "Problema", "Solucion" },
                values: new object[] { 1, 1, "Sin Cuerdas", "Comprar Cuerdas" });

            migrationBuilder.InsertData(
                table: "LlamadaDetalle",
                columns: new[] { "LlamadaDetalleId", "LlamadaId", "Problema", "Solucion" },
                values: new object[] { 2, 2, "Sin Bateria", "Comprar Bateria" });

            migrationBuilder.CreateIndex(
                name: "IX_LlamadaDetalle_LlamadaId",
                table: "LlamadaDetalle",
                column: "LlamadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LlamadaDetalle");

            migrationBuilder.DropTable(
                name: "Llamadas");
        }
    }
}
