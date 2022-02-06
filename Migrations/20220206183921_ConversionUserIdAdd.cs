using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class ConversionUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Conversions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_CreatedById",
                table: "Conversions",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversions_Users_CreatedById",
                table: "Conversions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversions_Users_CreatedById",
                table: "Conversions");

            migrationBuilder.DropIndex(
                name: "IX_Conversions_CreatedById",
                table: "Conversions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Conversions");
        }
    }
}
