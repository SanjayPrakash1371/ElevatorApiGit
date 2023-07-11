using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeerToPeerResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomainatedEmpId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomainaterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    citation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerToPeerResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_PeerToPeerResults_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Employees_empId1",
                        column: x => x.empId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeerToPeer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    awardCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    month = table.Column<int>(type: "int", nullable: true),
                    citation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    empId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<int>(type: "int", nullable: true),
                    Resultsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerToPeer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeerToPeer_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeerToPeer_PeerToPeerResults_Resultsid",
                        column: x => x.Resultsid,
                        principalTable: "PeerToPeerResults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeer_employeeId",
                table: "PeerToPeer",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeer_Resultsid",
                table: "PeerToPeer",
                column: "Resultsid");

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeerResults_employeeId",
                table: "PeerToPeerResults",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_empId1",
                table: "Roles",
                column: "empId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeerToPeer");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "PeerToPeerResults");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
