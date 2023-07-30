using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class AddedMarketUrlOnServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarketUrl",
                table: "Servers",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestVerificationToken",
                table: "Servers",
                type: "varchar(500)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketUrl",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "RequestVerificationToken",
                table: "Servers");
        }
    }
}
