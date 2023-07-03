using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiNewExample.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_liftLoggers_LiftLoggerid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LiftLoggerid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LiftLoggerid",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LiftLoggerid",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LiftLoggerid",
                table: "Employees",
                column: "LiftLoggerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_liftLoggers_LiftLoggerid",
                table: "Employees",
                column: "LiftLoggerid",
                principalTable: "liftLoggers",
                principalColumn: "id");
        }
    }
}
