using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyActivity.Migrations
{
    public partial class RemoveEmpId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEnrollments_Employees_EmployeeId",
                table: "ActivityEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEnrollments_EmployeeId",
                table: "ActivityEnrollments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ActivityEnrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ActivityEnrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_EmployeeId",
                table: "ActivityEnrollments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEnrollments_Employees_EmployeeId",
                table: "ActivityEnrollments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
