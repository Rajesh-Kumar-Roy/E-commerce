using Microsoft.EntityFrameworkCore.Migrations;

namespace Bootstrapdb.Migrations
{
    public partial class subCatagories_Image_property_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SubCategorieses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SubCategorieses");
        }
    }
}
