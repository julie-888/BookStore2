using DOTNET_6.EntityFramework;
using DOTNET_6.Models;
using DOTNET_6.Repository.FileRepositories;

namespace DOTNET_6.Repository.EntityFrameworkRepositories
{
    public class EfCoreBookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        public EfCoreBookRepository(IServiceScopeFactory scopeFactory)
        {

            var scope = scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            _db = db;
        }

        public Book Add(Book model)
        {
            _db.Books.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var book = _db.Books.First(f => f.Id == id);
            _db.Books.Remove(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public Book GetById(int id)
        {
            var book = _db.Books.First(f => f.Id == id);
            return book;
        }

        public Book Update(Book model)
        {
            _db.Books.Update(model);
            return model;
        }
    }
}
