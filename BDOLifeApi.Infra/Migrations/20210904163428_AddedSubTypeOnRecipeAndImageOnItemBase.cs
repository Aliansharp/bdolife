using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class AddedSubTypeOnRecipeAndImageOnItemBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Itens",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubType",
                table: "Itens",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "SubType",
                table: "Itens");
        }
    }
}
