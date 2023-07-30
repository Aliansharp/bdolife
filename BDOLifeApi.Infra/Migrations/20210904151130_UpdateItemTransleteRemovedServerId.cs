using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class UpdateItemTransleteRemovedServerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTranslate_Servers_ServerId",
                table: "ItemTranslate");

            migrationBuilder.DropIndex(
                name: "IX_ItemTranslate_ServerId",
                table: "ItemTranslate");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "ItemTranslate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServerId",
                table: "ItemTranslate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemTranslate_ServerId",
                table: "ItemTranslate",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTranslate_Servers_ServerId",
                table: "ItemTranslate",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
