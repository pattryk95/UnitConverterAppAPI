using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class AddNewTableConversionResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalValue",
                table: "Conversions");

            migrationBuilder.AddColumn<int>(
                name: "ConversionResultId",
                table: "Conversions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConversionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalValue = table.Column<decimal>(type: "decimal(38,19)", precision: 38, scale: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionResults", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_ConversionResultId",
                table: "Conversions",
                column: "ConversionResultId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversions_ConversionResults_ConversionResultId",
                table: "Conversions",
                column: "ConversionResultId",
                principalTable: "ConversionResults",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversions_ConversionResults_ConversionResultId",
                table: "Conversions");

            migrationBuilder.DropTable(
                name: "ConversionResults");

            migrationBuilder.DropIndex(
                name: "IX_Conversions_ConversionResultId",
                table: "Conversions");

            migrationBuilder.DropColumn(
                name: "ConversionResultId",
                table: "Conversions");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalValue",
                table: "Conversions",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
