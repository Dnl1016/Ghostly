using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghostly.Web.Migrations
{
    public partial class CompleteDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Ventas",
                newName: "ClientesId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                newName: "IX_Ventas_ClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClientesId",
                table: "Ventas",
                column: "ClientesId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClientesId",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "ClientesId",
                table: "Ventas",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClientesId",
                table: "Ventas",
                newName: "IX_Ventas_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClienteId",
                table: "Ventas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
