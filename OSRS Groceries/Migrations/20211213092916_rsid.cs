using Microsoft.EntityFrameworkCore.Migrations;

namespace OSRS_Groceries.Migrations
{
    public partial class rsid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RSID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RSID",
                table: "Items");
        }
    }
}
