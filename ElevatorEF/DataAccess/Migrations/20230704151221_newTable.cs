using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elevators_LiftLogs_logid",
                table: "Elevators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elevators",
                table: "Elevators");

            migrationBuilder.RenameTable(
                name: "Elevators",
                newName: "ElevatorLogs");

            migrationBuilder.RenameIndex(
                name: "IX_Elevators_logid",
                table: "ElevatorLogs",
                newName: "IX_ElevatorLogs_logid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElevatorLogs",
                table: "ElevatorLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "elevatorLoggings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    floorno = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    logid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elevatorLoggings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_elevatorLoggings_LiftLogs_logid",
                        column: x => x.logid,
                        principalTable: "LiftLogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_elevatorLoggings_logid",
                table: "elevatorLoggings",
                column: "logid");

            migrationBuilder.AddForeignKey(
                name: "FK_ElevatorLogs_LiftLogs_logid",
                table: "ElevatorLogs",
                column: "logid",
                principalTable: "LiftLogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElevatorLogs_LiftLogs_logid",
                table: "ElevatorLogs");

            migrationBuilder.DropTable(
                name: "elevatorLoggings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElevatorLogs",
                table: "ElevatorLogs");

            migrationBuilder.RenameTable(
                name: "ElevatorLogs",
                newName: "Elevators");

            migrationBuilder.RenameIndex(
                name: "IX_ElevatorLogs_logid",
                table: "Elevators",
                newName: "IX_Elevators_logid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elevators",
                table: "Elevators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Elevators_LiftLogs_logid",
                table: "Elevators",
                column: "logid",
                principalTable: "LiftLogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
