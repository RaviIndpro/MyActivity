using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyActivity.Migrations
{
    public partial class AddingEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeActivityId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityEnrollments_EmployeeActivities_EmployeeActivityId",
                        column: x => x.EmployeeActivityId,
                        principalTable: "EmployeeActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEnrollments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_EmployeeActivityId",
                table: "ActivityEnrollments",
                column: "EmployeeActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_EmployeeId",
                table: "ActivityEnrollments",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityEnrollments");
        }
    }
}
