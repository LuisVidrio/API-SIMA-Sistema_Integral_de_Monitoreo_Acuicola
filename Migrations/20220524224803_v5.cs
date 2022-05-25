using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOT_Modules_Ponds_PondId",
                table: "IOT_Modules");

            migrationBuilder.AlterColumn<int>(
                name: "PondId",
                table: "IOT_Modules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_IOT_Modules_Ponds_PondId",
                table: "IOT_Modules",
                column: "PondId",
                principalTable: "Ponds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOT_Modules_Ponds_PondId",
                table: "IOT_Modules");

            migrationBuilder.AlterColumn<int>(
                name: "PondId",
                table: "IOT_Modules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IOT_Modules_Ponds_PondId",
                table: "IOT_Modules",
                column: "PondId",
                principalTable: "Ponds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
