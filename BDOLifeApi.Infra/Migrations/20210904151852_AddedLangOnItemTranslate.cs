using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class AddedLangOnItemTranslate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "ItemTranslate",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "ItemTranslate");
        }
    }
}
