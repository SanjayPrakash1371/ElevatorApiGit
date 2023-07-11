using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAccess.Migrations
{
    /// <inheritdoc />
    public partial class Int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsUsers");

            migrationBuilder.AddColumn<int>(
                name: "Usersid",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Usersid",
                table: "Accounts",
                column: "Usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_Usersid",
                table: "Accounts",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_Usersid",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Usersid",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Usersid",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "AccountsUsers",
                columns: table => new
                {
                    Usersid = table.Column<int>(type: "int", nullable: false),
                    accountsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsUsers", x => new { x.Usersid, x.accountsid });
                    table.ForeignKey(
                        name: "FK_AccountsUsers_Accounts_accountsid",
                        column: x => x.accountsid,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsUsers_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsUsers_accountsid",
                table: "AccountsUsers",
                column: "accountsid");
        }
    }
}
