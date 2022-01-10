using Microsoft.EntityFrameworkCore.Migrations;

namespace OSRS_Groceries.Migrations
{
    public partial class NamechangeItemUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_Items_ItemID",
                table: "Items_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_Users_UserID",
                table: "Items_Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items_Users",
                table: "Items_Users");

            migrationBuilder.RenameTable(
                name: "Items_Users",
                newName: "Item_User");

            migrationBuilder.RenameIndex(
                name: "IX_Items_Users_UserID",
                table: "Item_User",
                newName: "IX_Item_User_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_Users_ItemID",
                table: "Item_User",
                newName: "IX_Item_User_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item_User",
                table: "Item_User",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_Items_ItemID",
                table: "Item_User",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_Users_UserID",
                table: "Item_User",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_Items_ItemID",
                table: "Item_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_Users_UserID",
                table: "Item_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item_User",
                table: "Item_User");

            migrationBuilder.RenameTable(
                name: "Item_User",
                newName: "Items_Users");

            migrationBuilder.RenameIndex(
                name: "IX_Item_User_UserID",
                table: "Items_Users",
                newName: "IX_Items_Users_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_User_ItemID",
                table: "Items_Users",
                newName: "IX_Items_Users_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items_Users",
                table: "Items_Users",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_Items_ItemID",
                table: "Items_Users",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_Users_UserID",
                table: "Items_Users",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
