using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitConverterAppAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvertedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfConversion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalUnitId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversions_Units_OriginalUnitId",
                        column: x => x.OriginalUnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conversions_Units_TargetUnitId",
                        column: x => x.TargetUnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_OriginalUnitId",
                table: "Conversions",
                column: "OriginalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_TargetUnitId",
                table: "Conversions",
                column: "TargetUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversions");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
