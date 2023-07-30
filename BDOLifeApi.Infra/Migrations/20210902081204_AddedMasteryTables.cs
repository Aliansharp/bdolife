using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class AddedMasteryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasteryAlchemy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mastery = table.Column<int>(type: "int", nullable: false),
                    RegularProc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RareProc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ImperialBonus = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaxProcChance = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ChanceRegular = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ChanceSpecial = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ChanceRare = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteryAlchemy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasteryCooking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mastery = table.Column<int>(type: "int", nullable: false),
                    RegularProc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RareProc = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CraftForDurability = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ImperialBonus = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RegularMaxProcChance = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    RareMaxProcChance = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteryCooking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasteryProcess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mastery = table.Column<int>(type: "int", nullable: false),
                    Batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteryProcess", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasteryAlchemy");

            migrationBuilder.DropTable(
                name: "MasteryCooking");

            migrationBuilder.DropTable(
                name: "MasteryProcess");
        }
    }
}
