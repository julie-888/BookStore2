using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOTNET_6.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Description", "ImageUrl", "IsBooked", "Name", "PublishDate" },
                values: new object[,]
                {
                    { 1, "Л.Н.Толстой", "Роман-эпопея русской литературы жанра классика", "https://cdn.ast.ru/v2/ASE000000000710286/COVER/cover1__w340.jpg", false, "Война и Мир", new DateTime(1865, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Ф.М.Достоевский", "Классический роман русской литературы", "https://img4.labirint.ru/rc/2691547166676f499a9b8d1f2fd81508/363x561q80/books86/853526/cover.jpg?1649679998", false, "Идиот", new DateTime(1876, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Артур Хейли", "Удивительная история", "https://ra-product-image.s3.eu-north-1.amazonaws.com/b9/c1/b9c13250c56c7499e9c1adf2bd503e04_main_1.jpg", false, "Аэропорт", new DateTime(1978, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Ги де Мопассан", "История любви французская классика", "https://irecommend.ru/sites/default/files/product-images/29033/7.jpg", false, "Милый друг", new DateTime(1885, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Ильф и Петров", "Комедийное произведение", "https://s3.vcdn.biz/static/f/818726421/image.jpg/pt/r300x423x4", false, "12 стульев", new DateTime(1924, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "М.А.Булгаков", "Удивительный мистический роман", "https://img3.labirint.ru/rc/1927058a57537edd854803f93079075d/363x561q80/books67/668307/cover.jpg?1618673120", false, "Мастер и Маргарита", new DateTime(1940, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Rene Goscinny", "Веселые истории о забавном Николя", "https://m.media-amazon.com/images/I/51BdA9Ir0FL.jpg", false, "Petit Nicolas", new DateTime(1962, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
