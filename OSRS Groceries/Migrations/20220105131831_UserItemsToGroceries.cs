using Microsoft.EntityFrameworkCore.Migrations;

namespace OSRS_Groceries.Migrations
{
    public partial class UserItemsToGroceries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Items_ItemID",
                table: "UserItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserItems_Users_UserID",
                table: "UserItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems");

            migrationBuilder.RenameTable(
                name: "UserItems",
                newName: "Groceries");

            migrationBuilder.RenameIndex(
                name: "IX_UserItems_UserID",
                table: "Groceries",
                newName: "IX_Groceries_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserItems_ItemID",
                table: "Groceries",
                newName: "IX_Groceries_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groceries",
                table: "Groceries",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_Items_ItemID",
                table: "Groceries",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_Users_UserID",
                table: "Groceries",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_Items_ItemID",
                table: "Groceries");

            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_Users_UserID",
                table: "Groceries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groceries",
                table: "Groceries");

            migrationBuilder.RenameTable(
                name: "Groceries",
                newName: "UserItems");

            migrationBuilder.RenameIndex(
                name: "IX_Groceries_UserID",
                table: "UserItems",
                newName: "IX_UserItems_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Groceries_ItemID",
                table: "UserItems",
                newName: "IX_UserItems_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserItems",
                table: "UserItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Items_ItemID",
                table: "UserItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserItems_Users_UserID",
                table: "UserItems",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
