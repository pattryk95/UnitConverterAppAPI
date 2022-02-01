using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class ChangeNameOfColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionResults");

            migrationBuilder.AddColumn<decimal>(
                name: "ConversionResult",
                table: "Conversions",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionResult",
                table: "Conversions");

            migrationBuilder.CreateTable(
                name: "ConversionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionId = table.Column<int>(type: "int", nullable: false),
                    FinalValue = table.Column<decimal>(type: "decimal(38,19)", precision: 38, scale: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversionResults_Conversions_ConversionId",
                        column: x => x.ConversionId,
                        principalTable: "Conversions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionResults_ConversionId",
                table: "ConversionResults",
                column: "ConversionId",
                unique: true);
        }
    }
}
