using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboCafes.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parafertils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(maxLength: 100, nullable: false),
                    Meses = table.Column<int>(nullable: false),
                    PalosDesde = table.Column<int>(nullable: false),
                    PalosHasta = table.Column<int>(nullable: false),
                    Phdesde = table.Column<int>(nullable: false),
                    PhHasta = table.Column<int>(nullable: false),
                    CantidadKN = table.Column<int>(nullable: false),
                    CantidadKP = table.Column<int>(nullable: false),
                    CantidadKF = table.Column<int>(nullable: false),
                    Menores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parafertils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Detalle = table.Column<string>(maxLength: 100, nullable: true),
                    CantidadKN = table.Column<int>(nullable: false),
                    CantidadKP = table.Column<int>(nullable: false),
                    CantidadKF = table.Column<int>(nullable: false),
                    Menores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DepartamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corregimientos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CiudadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corregimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corregimientos_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tercero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Documento = table.Column<string>(maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    CiudadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tercero_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veredas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CorregimientoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veredas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veredas_Corregimientos_CorregimientoId",
                        column: x => x.CorregimientoId,
                        principalTable: "Corregimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fincas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Propietario = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    TerceroId = table.Column<int>(nullable: true),
                    VeredaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fincas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fincas_Tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalTable: "Tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fincas_Veredas_VeredaId",
                        column: x => x.VeredaId,
                        principalTable: "Veredas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FincaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Fincas_FincaId",
                        column: x => x.FincaId,
                        principalTable: "Fincas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hectareas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 40, nullable: false),
                    Palos = table.Column<int>(nullable: false),
                    Siembra = table.Column<DateTime>(nullable: false),
                    Arrobas = table.Column<int>(nullable: false),
                    CantidadKN = table.Column<int>(nullable: false),
                    CantidadKP = table.Column<int>(nullable: false),
                    CantidadKF = table.Column<int>(nullable: false),
                    Menores = table.Column<int>(nullable: false),
                    Ph = table.Column<decimal>(nullable: false),
                    LoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hectareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hectareas_Lotes_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_DepartamentoId",
                table: "Ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_Name",
                table: "Ciudades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corregimientos_CiudadId",
                table: "Corregimientos",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Corregimientos_Name",
                table: "Corregimientos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Name",
                table: "Departamentos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fincas_TerceroId",
                table: "Fincas",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_Fincas_VeredaId",
                table: "Fincas",
                column: "VeredaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hectareas_LoteId",
                table: "Hectareas",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_FincaId",
                table: "Lotes",
                column: "FincaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_CiudadId",
                table: "Tercero",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_Documento",
                table: "Tercero",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veredas_CorregimientoId",
                table: "Veredas",
                column: "CorregimientoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hectareas");

            migrationBuilder.DropTable(
                name: "Parafertils");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Fincas");

            migrationBuilder.DropTable(
                name: "Tercero");

            migrationBuilder.DropTable(
                name: "Veredas");

            migrationBuilder.DropTable(
                name: "Corregimientos");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
