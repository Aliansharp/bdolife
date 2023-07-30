using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class ChangeNameItensTranslates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTranslate_Itens_ItemId",
                table: "ItemTranslate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTranslate",
                table: "ItemTranslate");

            migrationBuilder.RenameTable(
                name: "ItemTranslate",
                newName: "ItensTranslates");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTranslate_ItemId",
                table: "ItensTranslates",
                newName: "IX_ItensTranslates_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensTranslates",
                table: "ItensTranslates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensTranslates_Itens_ItemId",
                table: "ItensTranslates",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensTranslates_Itens_ItemId",
                table: "ItensTranslates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensTranslates",
                table: "ItensTranslates");

            migrationBuilder.RenameTable(
                name: "ItensTranslates",
                newName: "ItemTranslate");

            migrationBuilder.RenameIndex(
                name: "IX_ItensTranslates_ItemId",
                table: "ItemTranslate",
                newName: "IX_ItemTranslate_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTranslate",
                table: "ItemTranslate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTranslate_Itens_ItemId",
                table: "ItemTranslate",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
