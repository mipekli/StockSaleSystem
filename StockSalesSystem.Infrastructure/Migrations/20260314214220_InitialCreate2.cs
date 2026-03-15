using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockSalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMaps_CategoryId",
                table: "CategoryMaps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMaps_ProductId",
                table: "CategoryMaps",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaps_Categories_CategoryId",
                table: "CategoryMaps",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMaps_Products_ProductId",
                table: "CategoryMaps",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaps_Categories_CategoryId",
                table: "CategoryMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMaps_Products_ProductId",
                table: "CategoryMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMaps_CategoryId",
                table: "CategoryMaps");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMaps_ProductId",
                table: "CategoryMaps");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
