using Microsoft.EntityFrameworkCore.Migrations;

namespace OSRS_Groceries.Migrations
{
    public partial class rmvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
