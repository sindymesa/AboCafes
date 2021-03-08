using Microsoft.EntityFrameworkCore.Migrations;

namespace AboCafes.Web.Migrations
{
    public partial class Terceros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fincas_Tercero_TerceroId",
                table: "Fincas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tercero_Ciudades_CiudadId",
                table: "Tercero");

            migrationBuilder.DropIndex(
                name: "IX_Fincas_TerceroId",
                table: "Fincas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tercero",
                table: "Tercero");

            migrationBuilder.DropColumn(
                name: "Propietario",
                table: "Fincas");

            migrationBuilder.RenameTable(
                name: "Tercero",
                newName: "Terceros");

            migrationBuilder.RenameIndex(
                name: "IX_Tercero_Documento",
                table: "Terceros",
                newName: "IX_Terceros_Documento");

            migrationBuilder.RenameIndex(
                name: "IX_Tercero_CiudadId",
                table: "Terceros",
                newName: "IX_Terceros_CiudadId");

            migrationBuilder.AlterColumn<string>(
                name: "TerceroId",
                table: "Fincas",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TercerosId",
                table: "Fincas",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terceros",
                table: "Terceros",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Terceros_Ciudades_CiudadId",
                table: "Terceros",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fincas_Terceros_TercerosId",
                table: "Fincas");

            migrationBuilder.DropForeignKey(
                name: "FK_Terceros_Ciudades_CiudadId",
                table: "Terceros");

            migrationBuilder.DropIndex(
                name: "IX_Fincas_TercerosId",
                table: "Fincas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terceros",
                table: "Terceros");

            migrationBuilder.DropColumn(
                name: "TercerosId",
                table: "Fincas");

            migrationBuilder.RenameTable(
                name: "Terceros",
                newName: "Tercero");

            migrationBuilder.RenameIndex(
                name: "IX_Terceros_Documento",
                table: "Tercero",
                newName: "IX_Tercero_Documento");

            migrationBuilder.RenameIndex(
                name: "IX_Terceros_CiudadId",
                table: "Tercero",
                newName: "IX_Tercero_CiudadId");

            migrationBuilder.AlterColumn<int>(
                name: "TerceroId",
                table: "Fincas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<string>(
                name: "Propietario",
                table: "Fincas",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tercero",
                table: "Tercero",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fincas_TerceroId",
                table: "Fincas",
                column: "TerceroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fincas_Tercero_TerceroId",
                table: "Fincas",
                column: "TerceroId",
                principalTable: "Tercero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tercero_Ciudades_CiudadId",
                table: "Tercero",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
