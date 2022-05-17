using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportAPI.Migrations
{
    public partial class RenameProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimeRegisters",
                newName: "TimeRegisterId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeRegisterId",
                table: "TimeRegisters",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");
        }
    }
}
