using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class ChangedDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Factor",
                table: "Units",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalValue",
                table: "Conversions",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConvertedValue",
                table: "Conversions",
                type: "decimal(38,19)",
                precision: 38,
                scale: 19,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Factor",
                table: "Units",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalValue",
                table: "Conversions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "ConvertedValue",
                table: "Conversions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,19)",
                oldPrecision: 38,
                oldScale: 19);
        }
    }
}
