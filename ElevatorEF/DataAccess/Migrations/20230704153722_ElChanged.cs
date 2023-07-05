using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ElChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElevatorLogs_LiftLogs_logid",
                table: "ElevatorLogs");

            migrationBuilder.DropIndex(
                name: "IX_ElevatorLogs_logid",
                table: "ElevatorLogs");

            migrationBuilder.DropColumn(
                name: "logid",
                table: "ElevatorLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "logid",
                table: "ElevatorLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorLogs_logid",
                table: "ElevatorLogs",
                column: "logid");

            migrationBuilder.AddForeignKey(
                name: "FK_ElevatorLogs_LiftLogs_logid",
                table: "ElevatorLogs",
                column: "logid",
                principalTable: "LiftLogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
