using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAFTLECOME.Migrations
{
    /// <inheritdoc />
    public partial class normalpro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CheckPrice",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductId",
                table: "Stock");

            migrationBuilder.AddColumn<double>(
                name: "CheckPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId",
                unique: true);
        }
    }
}
