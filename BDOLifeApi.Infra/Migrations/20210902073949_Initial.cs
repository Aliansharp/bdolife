using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDOLife.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellNPCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Localization = table.Column<string>(type: "varchar(250)", nullable: true),
                    NightTime = table.Column<bool>(type: "bit", nullable: false),
                    NightTimeHour = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellNPCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: true),
                    Language = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BDOReference = table.Column<string>(type: "varchar(30)", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectDuration = table.Column<int>(type: "int", nullable: true),
                    Cooldown = table.Column<int>(type: "int", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    SkillLevel = table.Column<int>(type: "int", nullable: true),
                    EXP = table.Column<int>(type: "int", nullable: true),
                    QtdMaterial1 = table.Column<int>(type: "int", nullable: true),
                    QtdMaterial2 = table.Column<int>(type: "int", nullable: true),
                    QtdMaterial3 = table.Column<int>(type: "int", nullable: true),
                    QtdMaterial4 = table.Column<int>(type: "int", nullable: true),
                    QtdMaterial5 = table.Column<int>(type: "int", nullable: true),
                    Material1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Material2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Material3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Material4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Material5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialGroup1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialGroup2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialGroup3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialGroup4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialGroup5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QtdProduct1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QtdProduct2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Product1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Product2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Material1Id",
                        column: x => x.Material1Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Material2Id",
                        column: x => x.Material2Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Material3Id",
                        column: x => x.Material3Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Material4Id",
                        column: x => x.Material4Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Material5Id",
                        column: x => x.Material5Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Product1Id",
                        column: x => x.Product1Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Itens_Product2Id",
                        column: x => x.Product2Id,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroup1Id",
                        column: x => x.MaterialGroup1Id,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroup2Id",
                        column: x => x.MaterialGroup2Id,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroup3Id",
                        column: x => x.MaterialGroup3Id,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroup4Id",
                        column: x => x.MaterialGroup4Id,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroup5Id",
                        column: x => x.MaterialGroup5Id,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_MaterialGroups_MaterialGroupId",
                        column: x => x.MaterialGroupId,
                        principalTable: "MaterialGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    InStock = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellNPCsItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellNPCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    AmityRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellNPCsItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellNPCsItens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellNPCsItens_SellNPCs_SellNPCId",
                        column: x => x.SellNPCId,
                        principalTable: "SellNPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Material1Id",
                table: "Itens",
                column: "Material1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Material2Id",
                table: "Itens",
                column: "Material2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Material3Id",
                table: "Itens",
                column: "Material3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Material4Id",
                table: "Itens",
                column: "Material4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Material5Id",
                table: "Itens",
                column: "Material5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroup1Id",
                table: "Itens",
                column: "MaterialGroup1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroup2Id",
                table: "Itens",
                column: "MaterialGroup2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroup3Id",
                table: "Itens",
                column: "MaterialGroup3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroup4Id",
                table: "Itens",
                column: "MaterialGroup4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroup5Id",
                table: "Itens",
                column: "MaterialGroup5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialGroupId",
                table: "Itens",
                column: "MaterialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Product1Id",
                table: "Itens",
                column: "Product1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Product2Id",
                table: "Itens",
                column: "Product2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ItemId",
                table: "Prices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ServerId",
                table: "Prices",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellNPCsItens_ItemId",
                table: "SellNPCsItens",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SellNPCsItens_SellNPCId",
                table: "SellNPCsItens",
                column: "SellNPCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "SellNPCsItens");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "SellNPCs");

            migrationBuilder.DropTable(
                name: "MaterialGroups");
        }
    }
}
