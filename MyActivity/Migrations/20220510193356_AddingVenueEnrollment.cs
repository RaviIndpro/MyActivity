using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyActivity.Migrations
{
    public partial class AddingVenueEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VenueEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeActivityId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueEnrollments_EmployeeActivities_EmployeeActivityId",
                        column: x => x.EmployeeActivityId,
                        principalTable: "EmployeeActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenueEnrollments_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VenueEnrollments_EmployeeActivityId",
                table: "VenueEnrollments",
                column: "EmployeeActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueEnrollments_VenueId",
                table: "VenueEnrollments",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VenueEnrollments");
        }
    }
}
