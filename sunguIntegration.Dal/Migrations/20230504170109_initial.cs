using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrendyolCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    TrendyolCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrendyolCategories_TrendyolCategories_TrendyolCategoryId",
                        column: x => x.TrendyolCategoryId,
                        principalTable: "TrendyolCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrendyolUserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolApi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrendyolSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolUserInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrendyolCategories_TrendyolCategoryId",
                table: "TrendyolCategories",
                column: "TrendyolCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrendyolCategories");

            migrationBuilder.DropTable(
                name: "TrendyolUserInfos");
        }
    }
}
