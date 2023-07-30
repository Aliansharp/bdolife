using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class AddedMaterialsGroupsTranslatedAndBDOReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BDOReference",
                table: "MaterialGroups",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialGroupTranslate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameTranslated = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Lang = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialGroupTranslate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialGroupTranslate_MaterialGroups_MaterialGroupId",
                        column: x => x.MaterialGroupId,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialGroupTranslate_MaterialGroupId",
                table: "MaterialGroupTranslate",
                column: "MaterialGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialGroupTranslate");

            migrationBuilder.DropColumn(
                name: "BDOReference",
                table: "MaterialGroups");
        }
    }
}
