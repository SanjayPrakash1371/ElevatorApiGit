using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeerToPeer_PeerToPeerResults_Resultsid",
                table: "PeerToPeer");

            migrationBuilder.AlterColumn<int>(
                name: "Resultsid",
                table: "PeerToPeer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PeerToPeer_PeerToPeerResults_Resultsid",
                table: "PeerToPeer",
                column: "Resultsid",
                principalTable: "PeerToPeerResults",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeerToPeer_PeerToPeerResults_Resultsid",
                table: "PeerToPeer");

            migrationBuilder.AlterColumn<int>(
                name: "Resultsid",
                table: "PeerToPeer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PeerToPeer_PeerToPeerResults_Resultsid",
                table: "PeerToPeer",
                column: "Resultsid",
                principalTable: "PeerToPeerResults",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
