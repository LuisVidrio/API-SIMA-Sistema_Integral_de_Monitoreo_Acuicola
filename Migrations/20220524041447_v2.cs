using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "machine",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "node",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "release",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "system",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "version",
                table: "IOT_Modules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "machine",
                table: "IOT_Modules");

            migrationBuilder.DropColumn(
                name: "node",
                table: "IOT_Modules");

            migrationBuilder.DropColumn(
                name: "release",
                table: "IOT_Modules");

            migrationBuilder.DropColumn(
                name: "system",
                table: "IOT_Modules");

            migrationBuilder.DropColumn(
                name: "version",
                table: "IOT_Modules");
        }
    }
}
