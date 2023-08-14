using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class brandServiceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrendyolBrandId",
                table: "TrendyolCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrendyolBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolBrands", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrendyolCategories_TrendyolBrands_TrendyolBrandId",
                table: "TrendyolCategories");

            migrationBuilder.DropTable(
                name: "TrendyolBrands");

            migrationBuilder.DropIndex(
                name: "IX_TrendyolCategories_TrendyolBrandId",
                table: "TrendyolCategories");

            migrationBuilder.DropColumn(
                name: "TrendyolBrandId",
                table: "TrendyolCategories");
        }
    }
}
