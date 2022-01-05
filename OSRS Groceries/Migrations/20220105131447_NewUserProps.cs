using Microsoft.EntityFrameworkCore.Migrations;

namespace OSRS_Groceries.Migrations
{
    public partial class NewUserProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Biem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Biem",
                table: "Users",
                newName: "Password");
        }
    }
}
