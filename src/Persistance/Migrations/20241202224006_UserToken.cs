using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UserToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductConditionId",
                table: "Products",
                column: "ProductConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCondition_ProductConditionId",
                table: "Products",
                column: "ProductConditionId",
                principalTable: "ProductCondition",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCondition_ProductConditionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductConditionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");
        }
    }
}
