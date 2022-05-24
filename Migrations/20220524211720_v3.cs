using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "machine",
                table: "IOT_Modules");

            migrationBuilder.RenameColumn(
                name: "system",
                table: "IOT_Modules",
                newName: "serial");

            migrationBuilder.RenameColumn(
                name: "node",
                table: "IOT_Modules",
                newName: "CPU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "serial",
                table: "IOT_Modules",
                newName: "system");

            migrationBuilder.RenameColumn(
                name: "CPU",
                table: "IOT_Modules",
                newName: "node");

            migrationBuilder.AddColumn<string>(
                name: "machine",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
