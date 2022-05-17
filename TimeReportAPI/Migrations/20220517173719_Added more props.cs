using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReportAPI.Migrations
{
    public partial class Addedmoreprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRegisters_Projects_ProjectId",
                table: "TimeRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TimeRegisters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRegisters_Projects_ProjectId",
                table: "TimeRegisters",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRegisters_Projects_ProjectId",
                table: "TimeRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TimeRegisters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRegisters_Projects_ProjectId",
                table: "TimeRegisters",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
