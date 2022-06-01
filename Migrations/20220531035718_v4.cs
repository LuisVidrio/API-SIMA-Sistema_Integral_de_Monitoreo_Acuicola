using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ponds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ponds_UserId",
                table: "Ponds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ponds_Users_UserId",
                table: "Ponds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ponds_Users_UserId",
                table: "Ponds");

            migrationBuilder.DropIndex(
                name: "IX_Ponds_UserId",
                table: "Ponds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ponds");
        }
    }
}
