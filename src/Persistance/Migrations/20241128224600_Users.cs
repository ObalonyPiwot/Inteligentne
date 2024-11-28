using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productes_Brand_BrandId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductCategory_ProductCategoryId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductColor_ProductColorId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductGender_ProductGenderId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductMaterial_ProductMaterialId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductSeason_ProductSeasonId",
                table: "Productes");

            migrationBuilder.DropForeignKey(
                name: "FK_Productes_ProductType_ProductTypeId",
                table: "Productes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productes",
                table: "Productes");

            migrationBuilder.RenameTable(
                name: "Productes",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductTypeId",
                table: "Products",
                newName: "IX_Products_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductSeasonId",
                table: "Products",
                newName: "IX_Products_ProductSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductMaterialId",
                table: "Products",
                newName: "IX_Products_ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductGenderId",
                table: "Products",
                newName: "IX_Products_ProductGenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductColorId",
                table: "Products",
                newName: "IX_Products_ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Productes_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brand_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductColor_ProductColorId",
                table: "Products",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGender_ProductGenderId",
                table: "Products",
                column: "ProductGenderId",
                principalTable: "ProductGender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductMaterial_ProductMaterialId",
                table: "Products",
                column: "ProductMaterialId",
                principalTable: "ProductMaterial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSeason_ProductSeasonId",
                table: "Products",
                column: "ProductSeasonId",
                principalTable: "ProductSeason",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brand_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColor_ProductColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGender_ProductGenderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMaterial_ProductMaterialId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSeason_ProductSeasonId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productes");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductTypeId",
                table: "Productes",
                newName: "IX_Productes_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductSeasonId",
                table: "Productes",
                newName: "IX_Productes_ProductSeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductMaterialId",
                table: "Productes",
                newName: "IX_Productes_ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductGenderId",
                table: "Productes",
                newName: "IX_Productes_ProductGenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductColorId",
                table: "Productes",
                newName: "IX_Productes_ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Productes",
                newName: "IX_Productes_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Productes",
                newName: "IX_Productes_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productes",
                table: "Productes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_Brand_BrandId",
                table: "Productes",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductCategory_ProductCategoryId",
                table: "Productes",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductColor_ProductColorId",
                table: "Productes",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductGender_ProductGenderId",
                table: "Productes",
                column: "ProductGenderId",
                principalTable: "ProductGender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductMaterial_ProductMaterialId",
                table: "Productes",
                column: "ProductMaterialId",
                principalTable: "ProductMaterial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductSeason_ProductSeasonId",
                table: "Productes",
                column: "ProductSeasonId",
                principalTable: "ProductSeason",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productes_ProductType_ProductTypeId",
                table: "Productes",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id");
        }
    }
}
