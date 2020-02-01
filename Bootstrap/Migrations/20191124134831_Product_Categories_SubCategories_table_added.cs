using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bootstrapdb.Migrations
{
    public partial class Product_Categories_SubCategories_table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catagorieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagorieses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorieses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CategoriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorieses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategorieses_Catagorieses_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Catagorieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    ProductModel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CatagoriesId = table.Column<int>(nullable: false),
                    SubCategoriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Catagorieses_CatagoriesId",
                        column: x => x.CatagoriesId,
                        principalTable: "Catagorieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategorieses_SubCategoriesId",
                        column: x => x.SubCategoriesId,
                        principalTable: "SubCategorieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoriesId",
                table: "Products",
                column: "CatagoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoriesId",
                table: "Products",
                column: "SubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategorieses_CategoriesId",
                table: "SubCategorieses",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SubCategorieses");

            migrationBuilder.DropTable(
                name: "Catagorieses");
        }
    }
}
