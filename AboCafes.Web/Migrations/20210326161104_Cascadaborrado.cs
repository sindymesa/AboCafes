using Microsoft.EntityFrameworkCore.Migrations;

namespace AboCafes.Web.Migrations
{
    public partial class Cascadaborrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_Corregimientos_Ciudades_CiudadId",
                table: "Corregimientos");

            migrationBuilder.DropIndex(
                name: "IX_Corregimientos_Name",
                table: "Corregimientos");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_Name",
                table: "Ciudades");

            migrationBuilder.CreateIndex(
                name: "IX_Corregimientos_Name_CiudadId",
                table: "Corregimientos",
                columns: new[] { "Name", "CiudadId" },
                unique: true,
                filter: "[CiudadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Name_DepartamentoId",
                table: "Ciudades",
                columns: new[] { "Name", "DepartamentoId" },
                unique: true,
                filter: "[DepartamentoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Corregimientos_Ciudades_CiudadId",
                table: "Corregimientos",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades");

            migrationBuilder.DropForeignKey(
                name: "FK_Corregimientos_Ciudades_CiudadId",
                table: "Corregimientos");

            migrationBuilder.DropIndex(
                name: "IX_Corregimientos_Name_CiudadId",
                table: "Corregimientos");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_Name_DepartamentoId",
                table: "Ciudades");

            migrationBuilder.CreateIndex(
                name: "IX_Corregimientos_Name",
                table: "Corregimientos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Name",
                table: "Ciudades",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Departamentos_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Corregimientos_Ciudades_CiudadId",
                table: "Corregimientos",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
