using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class trendyolIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrendyolId",
                table: "TrendyolCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrendyolId",
                table: "TrendyolCategories");
        }
    }
}
