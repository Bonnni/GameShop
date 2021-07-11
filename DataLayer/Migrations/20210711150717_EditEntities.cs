using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class EditEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_GenreID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "company");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "genre");

            migrationBuilder.RenameIndex(
                name: "IX_Products_GenreID",
                table: "product",
                newName: "IX_product_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "product",
                newName: "IX_product_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company",
                table: "company",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_genre",
                table: "genre",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_company_CompanyId",
                table: "product",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_genre_GenreID",
                table: "product",
                column: "GenreID",
                principalTable: "genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_company_CompanyId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_genre_GenreID",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company",
                table: "company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_genre",
                table: "genre");

            migrationBuilder.RenameTable(
                name: "company",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "genre",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_product_GenreID",
                table: "Products",
                newName: "IX_Products_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_product_CompanyId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_GenreID",
                table: "Products",
                column: "GenreID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
