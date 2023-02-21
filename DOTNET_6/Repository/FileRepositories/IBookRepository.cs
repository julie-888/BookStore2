using DOTNET_6.Models;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;

namespace DOTNET_6.Repository.FileRepositories
{
    public interface IBookRepository : IRepository<Book, int>
    {

    }

    public class FileBookRepository : IBookRepository
    {
        private readonly string _path;

        public FileBookRepository(string path)
        {
            _path = path;
        }
        public void WriteToFile(List<Book> books)
        {
            using var sw = new StreamWriter(_path, false);
            var json = JsonConvert.SerializeObject(books);
            sw.Write(json);
        }
        public void Delete(int id)
        {
            var books = GetAll().ToList();
            var book = GetById(id);
            books.Remove(book);

            RemoveBookFromFile(book);
        }

        public IEnumerable<Book> GetAll()
        {
            using var sr = new StreamReader(_path);
            var json = sr.ReadToEnd();
            var books = JsonConvert.DeserializeObject<List<Book>>(json);
            return books;
        }

        public Book GetById(int id)
        {
            var books = GetAll();
            return books.First(f => f.Id == id);
        }

        public Book Update(Book model)
        {
            var book = GetById(model.Id);

            book.AuthorName = model.AuthorName;
            book.Description = model.Description;
            book.BookedBy = model.BookedBy;
            book.IsBooked = model.IsBooked;
            book.Name = model.Name;
            book.PublishDate = model.PublishDate;

            UpdateBookInFile(book);

            return book;
        }

        public void WriteToFile(Book model)
        {
            var books = GetAll().ToList();
            books.Add(model);

            using var sw = new StreamWriter(_path, false);
            var json = JsonConvert.SerializeObject(books);
            sw.Write(json);
        }

        public void UpdateBookInFile(Book bookToBeUpdated)
        {
            var books = GetAll().ToList();
            var source = books.First(f => f.Id == bookToBeUpdated.Id);
            books.Remove(source);
            books.Add(bookToBeUpdated);

            using var sw = new StreamWriter(_path, false);
            var json = JsonConvert.SerializeObject(books, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            sw.Write(json);
        }

        public void RemoveBookFromFile(Book model)
        {
            var books = GetAll().ToList();
            var source = books.First(f => f.Id == model.Id);
            books.Remove(source);

            using var sw = new StreamWriter(_path, false);
            var json = JsonConvert.SerializeObject(books);
            sw.Write(json);
        }

        public Book Add(Book model)
        {
            WriteToFile(model);
            return model;
        }
    }
}
