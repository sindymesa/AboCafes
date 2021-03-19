using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboCafes.Web.Migrations
{
    public partial class VH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fincas_Terceros_TercerosId",
                table: "Fincas");

            migrationBuilder.DropIndex(
                name: "IX_Fincas_TercerosId",
                table: "Fincas");

            migrationBuilder.DropColumn(
                name: "TercerosId",
                table: "Fincas");

            migrationBuilder.AddColumn<int>(
                name: "Altitud",
                table: "Hectareas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CafeId",
                table: "Hectareas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Distancia",
                table: "Hectareas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Sombrio",
                table: "Hectareas",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "TerceroId",
                table: "Fincas",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(maxLength: 50, nullable: false),
                    Variedad = table.Column<string>(maxLength: 50, nullable: false),
                    Detalle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hectareas_CafeId",
                table: "Hectareas",
                column: "CafeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fincas_TerceroId",
                table: "Fincas",
                column: "TerceroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fincas_Terceros_TerceroId",
                table: "Fincas",
                column: "TerceroId",
                principalTable: "Terceros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hectareas_Cafes_CafeId",
                table: "Hectareas",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fincas_Terceros_TerceroId",
                table: "Fincas");

            migrationBuilder.DropForeignKey(
                name: "FK_Hectareas_Cafes_CafeId",
                table: "Hectareas");

            migrationBuilder.DropTable(
                name: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Hectareas_CafeId",
                table: "Hectareas");

            migrationBuilder.DropIndex(
                name: "IX_Fincas_TerceroId",
                table: "Fincas");

            migrationBuilder.DropColumn(
                name: "Altitud",
                table: "Hectareas");

            migrationBuilder.DropColumn(
                name: "CafeId",
                table: "Hectareas");

            migrationBuilder.DropColumn(
                name: "Distancia",
                table: "Hectareas");

            migrationBuilder.DropColumn(
                name: "Sombrio",
                table: "Hectareas");

            migrationBuilder.AlterColumn<string>(
                name: "TerceroId",
                table: "Fincas",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TercerosId",
                table: "Fincas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fincas_TercerosId",
                table: "Fincas",
                column: "TercerosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fincas_Terceros_TercerosId",
                table: "Fincas",
                column: "TercerosId",
                principalTable: "Terceros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
