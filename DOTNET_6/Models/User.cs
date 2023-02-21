namespace DOTNET_6.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<Book> BooksToRefund { get; set; }
    }
}
