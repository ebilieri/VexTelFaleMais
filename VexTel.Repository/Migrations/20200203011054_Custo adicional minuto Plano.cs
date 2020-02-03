using Microsoft.EntityFrameworkCore.Migrations;

namespace VexTel.Repository.Migrations
{
    public partial class CustoadicionalminutoPlano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CustoAdicionalMinuto",
                table: "Planos",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustoAdicionalMinuto",
                table: "Planos");
        }
    }
}
