using DOTNET_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using static System.Net.WebRequestMethods;

namespace DOTNET_6.EntityFramework
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();

            modelBuilder.Entity<Book>().HasData(new List<Book>()
                        {
                            new Book()
                            {
                                Id = 1,
                                Name = "Война и Мир",
                                AuthorName = "Л.Н.Толстой",
                                PublishDate = new DateTime(1865,11,13),
                                Description = "Роман-эпопея русской литературы жанра классика",
                                IsBooked = false,
                                ImageUrl ="https://cdn.ast.ru/v2/ASE000000000710286/COVER/cover1__w340.jpg"

                            },
                            new Book()
                            {
                                Id = 2,
                                Name = "Идиот",
                                AuthorName = "Ф.М.Достоевский",
                                PublishDate = new DateTime(1876,12,10),
                                Description = "Классический роман русской литературы",
                                IsBooked = false,
                                ImageUrl ="https://img4.labirint.ru/rc/2691547166676f499a9b8d1f2fd81508/363x561q80/books86/853526/cover.jpg?1649679998"

                            },
                            new Book()
                            {
                                Id = 3,
                                Name = "Аэропорт",
                                AuthorName = "Артур Хейли",
                                PublishDate = new DateTime(1978,11,11),
                                Description = "Удивительная история",
                                IsBooked = false,
                                ImageUrl ="https://ra-product-image.s3.eu-north-1.amazonaws.com/b9/c1/b9c13250c56c7499e9c1adf2bd503e04_main_1.jpg"

                            },
                            new Book()
                            {
                                Id = 4,
                                Name = "Милый друг",
                                AuthorName = "Ги де Мопассан",
                                PublishDate = new DateTime(1885,10,10),
                                Description = "История любви французская классика",
                                IsBooked = false,
                                ImageUrl ="https://irecommend.ru/sites/default/files/product-images/29033/7.jpg"
                            },
                            new Book()
                            {
                                Id = 5,
                                Name = "12 стульев",
                                AuthorName = "Ильф и Петров",
                                PublishDate = new DateTime(1924,10,12),
                                Description = "Комедийное произведение",
                                IsBooked = false,
                                ImageUrl = "https://s3.vcdn.biz/static/f/818726421/image.jpg/pt/r300x423x4"


                            },
                            new Book()
                            {
                                Id = 6,
                                Name = "Мастер и Маргарита",
                                AuthorName = "М.А.Булгаков",
                                PublishDate = new DateTime(1940,11,12),
                                Description = "Удивительный мистический роман",
                                IsBooked = false,
                                ImageUrl = "https://img3.labirint.ru/rc/1927058a57537edd854803f93079075d/363x561q80/books67/668307/cover.jpg?1618673120",
                            },
                            new Book()
                            {
                                Id = 7,
                                Name = "Petit Nicolas",
                                AuthorName = "Rene Goscinny",
                                PublishDate = new DateTime(1962,9,8),
                                Description = "Веселые истории о забавном Николя",
                                IsBooked = false,
                                ImageUrl = "https://m.media-amazon.com/images/I/51BdA9Ir0FL.jpg"
                            }
                });
        }
    }
}
