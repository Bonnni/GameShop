using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_genre_GenreID",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_GenreID",
                table: "product");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "product");

            migrationBuilder.CreateTable(
                name: "GenreProduct",
                columns: table => new
                {
                    GenresID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreProduct", x => new { x.GenresID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_GenreProduct_genre_GenresID",
                        column: x => x.GenresID,
                        principalTable: "genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreProduct_product_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreProduct_ProductsID",
                table: "GenreProduct",
                column: "ProductsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreProduct");

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_GenreID",
                table: "product",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_product_genre_GenreID",
                table: "product",
                column: "GenreID",
                principalTable: "genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
