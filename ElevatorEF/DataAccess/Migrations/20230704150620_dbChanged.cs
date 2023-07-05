using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "logid",
                table: "Elevators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Elevators_logid",
                table: "Elevators",
                column: "logid");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_LiftLogs_logid",
                table: "Elevators",
                column: "logid",
                principalTable: "LiftLogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_LiftLogs_logid",
                table: "Elevators");

            migrationBuilder.DropIndex(
                name: "IX_Elevators_logid",
                table: "Elevators");

            migrationBuilder.DropColumn(
                name: "logid",
                table: "Elevators");
        }
    }
}
