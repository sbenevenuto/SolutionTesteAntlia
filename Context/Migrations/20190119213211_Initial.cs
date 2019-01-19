using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCosif",
                columns: table => new
                {
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductCosifId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodProductCosif = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCosif", x => x.ProductCosifId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ManualMovements",
                columns: table => new
                {
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifieldDate = table.Column<DateTime>(nullable: false),
                    ManualMovementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCosifId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualMovements", x => x.ManualMovementId);
                    table.ForeignKey(
                        name: "FK_ManualMovements_ProductCosif_ProductCosifId",
                        column: x => x.ProductCosifId,
                        principalTable: "ProductCosif",
                        principalColumn: "ProductCosifId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualMovements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManualMovements_ProductCosifId",
                table: "ManualMovements",
                column: "ProductCosifId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualMovements_ProductId",
                table: "ManualMovements",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManualMovements");

            migrationBuilder.DropTable(
                name: "ProductCosif");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
