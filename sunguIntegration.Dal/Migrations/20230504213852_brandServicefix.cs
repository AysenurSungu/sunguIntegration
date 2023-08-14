using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class brandServicefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrendyolCategories_TrendyolBrands_TrendyolBrandId",
                table: "TrendyolCategories");

            migrationBuilder.DropIndex(
                name: "IX_TrendyolCategories_TrendyolBrandId",
                table: "TrendyolCategories");

            migrationBuilder.DropColumn(
                name: "TrendyolBrandId",
                table: "TrendyolCategories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TrendyolBrands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrendyolBrandId",
                table: "TrendyolCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TrendyolBrands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrendyolCategories_TrendyolBrandId",
                table: "TrendyolCategories",
                column: "TrendyolBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrendyolCategories_TrendyolBrands_TrendyolBrandId",
                table: "TrendyolCategories",
                column: "TrendyolBrandId",
                principalTable: "TrendyolBrands",
                principalColumn: "Id");
        }
    }
}
