using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class AddNewTableConversionResultWithRefferenceModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversions_ConversionResults_ConversionResultId",
                table: "Conversions");

            migrationBuilder.DropIndex(
                name: "IX_Conversions_ConversionResultId",
                table: "Conversions");

            migrationBuilder.DropColumn(
                name: "ConversionResultId",
                table: "Conversions");

            migrationBuilder.AddColumn<int>(
                name: "ConversionId",
                table: "ConversionResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConversionResults_ConversionId",
                table: "ConversionResults",
                column: "ConversionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversionResults_Conversions_ConversionId",
                table: "ConversionResults",
                column: "ConversionId",
                principalTable: "Conversions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversionResults_Conversions_ConversionId",
                table: "ConversionResults");

            migrationBuilder.DropIndex(
                name: "IX_ConversionResults_ConversionId",
                table: "ConversionResults");

            migrationBuilder.DropColumn(
                name: "ConversionId",
                table: "ConversionResults");

            migrationBuilder.AddColumn<int>(
                name: "ConversionResultId",
                table: "Conversions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
