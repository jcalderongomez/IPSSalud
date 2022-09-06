using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSSalud.AccesoDatos.Migrations
{
    public partial class correcionTablaMunicipios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Departamento_DepatamentoId",
                table: "Municipio");

            migrationBuilder.DropIndex(
                name: "IX_Municipio_DepatamentoId",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "DepatamentoId",
                table: "Municipio");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoId",
                table: "Municipio",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Departamento_DepartamentoId",
                table: "Municipio",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Departamento_DepartamentoId",
                table: "Municipio");

            migrationBuilder.DropIndex(
                name: "IX_Municipio_DepartamentoId",
                table: "Municipio");

            migrationBuilder.AddColumn<int>(
                name: "DepatamentoId",
                table: "Municipio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepatamentoId",
                table: "Municipio",
                column: "DepatamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Departamento_DepatamentoId",
                table: "Municipio",
                column: "DepatamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
