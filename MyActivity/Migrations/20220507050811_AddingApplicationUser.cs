using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyActivity.Migrations
{
    public partial class AddingApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ActivityEnrollments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEnrollments_ApplicationUserId",
                table: "ActivityEnrollments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEnrollments_AspNetUsers_ApplicationUserId",
                table: "ActivityEnrollments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEnrollments_AspNetUsers_ApplicationUserId",
                table: "ActivityEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEnrollments_ApplicationUserId",
                table: "ActivityEnrollments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ActivityEnrollments");
        }
    }
}
