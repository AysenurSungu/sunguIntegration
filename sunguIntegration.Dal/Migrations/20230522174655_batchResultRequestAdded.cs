using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sunguIntegration.Dal.Migrations
{
    /// <inheritdoc />
    public partial class batchResultRequestAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchResultResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchRequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<long>(type: "bigint", nullable: false),
                    LastModification = table.Column<long>(type: "bigint", nullable: false),
                    SourceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCount = table.Column<long>(type: "bigint", nullable: false),
                    FailedItemCount = table.Column<long>(type: "bigint", nullable: false),
                    BatchRequestType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchResultResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestItem_TrendyolProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TrendyolProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestItemId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureReasons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchResultResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_BatchResultResponses_BatchResultResponseId",
                        column: x => x.BatchResultResponseId,
                        principalTable: "BatchResultResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Item_RequestItem_RequestItemId",
                        column: x => x.RequestItemId,
                        principalTable: "RequestItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_BatchResultResponseId",
                table: "Item",
                column: "BatchResultResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_RequestItemId",
                table: "Item",
                column: "RequestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestItem_ProductId",
                table: "RequestItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "BatchResultResponses");

            migrationBuilder.DropTable(
                name: "RequestItem");
        }
    }
}
