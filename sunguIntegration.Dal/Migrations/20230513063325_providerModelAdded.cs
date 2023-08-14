using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class providerModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrendyolDeliveryOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDuration = table.Column<long>(type: "bigint", nullable: false),
                    FastDeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolDeliveryOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrendyolProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrendyolProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMainId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    StockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimensionalWeight = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    VatRate = table.Column<long>(type: "bigint", nullable: false),
                    CargoCompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrendyolProducts_TrendyolDeliveryOptions_DeliveryOptionId",
                        column: x => x.DeliveryOptionId,
                        principalTable: "TrendyolDeliveryOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrendyolAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeValueId = table.Column<long>(type: "bigint", nullable: true),
                    CustomAttributeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrendyolProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrendyolAttributes_TrendyolProducts_TrendyolProductId",
                        column: x => x.TrendyolProductId,
                        principalTable: "TrendyolProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrendyolImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrendyolId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrendyolProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrendyolImages_TrendyolProducts_TrendyolProductId",
                        column: x => x.TrendyolProductId,
                        principalTable: "TrendyolProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrendyolAttributes_TrendyolProductId",
                table: "TrendyolAttributes",
                column: "TrendyolProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TrendyolImages_TrendyolProductId",
                table: "TrendyolImages",
                column: "TrendyolProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TrendyolProducts_DeliveryOptionId",
                table: "TrendyolProducts",
                column: "DeliveryOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrendyolAttributes");

            migrationBuilder.DropTable(
                name: "TrendyolImages");

            migrationBuilder.DropTable(
                name: "TrendyolProviders");

            migrationBuilder.DropTable(
                name: "TrendyolProducts");

            migrationBuilder.DropTable(
                name: "TrendyolDeliveryOptions");
        }
    }
}
