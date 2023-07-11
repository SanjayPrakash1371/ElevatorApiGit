using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_Usersid",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Usersid",
                table: "Accounts",
                newName: "usersid");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_Usersid",
                table: "Accounts",
                newName: "IX_Accounts_usersid");

            migrationBuilder.AlterColumn<int>(
                name: "usersid",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_usersid",
                table: "Accounts",
                column: "usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_usersid",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "usersid",
                table: "Accounts",
                newName: "Usersid");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_usersid",
                table: "Accounts",
                newName: "IX_Accounts_Usersid");

            migrationBuilder.AlterColumn<int>(
                name: "Usersid",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_Usersid",
                table: "Accounts",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
