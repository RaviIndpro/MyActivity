using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyActivity.Migrations
{
    public partial class gameDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "GameDate1",
                table: "VenueEnrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_EmployeeActivityId",
                table: "ActivityEnrollments",
                column: "EmployeeActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEnrollments_EmployeeActivities_EmployeeActivityId",
                table: "ActivityEnrollments",
                column: "EmployeeActivityId",
                principalTable: "EmployeeActivities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEnrollments_EmployeeActivities_EmployeeActivityId",
                table: "ActivityEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEnrollments_EmployeeActivityId",
                table: "ActivityEnrollments");

            migrationBuilder.DropColumn(
                name: "GameDate1",
                table: "VenueEnrollments");
        }
    }
}
