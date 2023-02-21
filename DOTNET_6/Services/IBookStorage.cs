using System.Text.Json;
using System.Text.Json.Serialization;
using DOTNET_6.Models;
using DOTNET_6.Repository;
using DOTNET_6.Repository.FileRepositories;

namespace DOTNET_6.Services;

public interface IBookStorage
{
    Book AddNewBook(string bookName,
        DateTime publishDate,
        string authorName
    );

    List<Book> GetBooks();
    Book GetBookById(int id);
}

public class BookStorage : IBookStorage
{
    private readonly IBookRepository _bookRepository;

    public BookStorage(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    //public static List<Book> Books = new List<Book>()
    //{
    //    new Book()
    //    {
    //        Id = 1,
    //        Name = "Война и мир",
    //        PublishDate = new DateTime(1867,9,5),
    //        AuthorName = "Л.Н Толстой",
    //        Description = "роман-эпопея Льва Николаевича Толстого, описывающий русское общество в эпоху войн против Наполеона в 1805—1812",
    //        ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1900788/ecbb3822-ee34-42f6-8480-e0920b41a050/600x900"

    //    },
    //    new Book()
    //    {
    //        Id = 2,
    //        Name = "Аэропорт",
    //        PublishDate = new DateTime(1900,9,5),
    //        AuthorName = "Артур Хейли",
    //        Description = "роман-бестселлер 1968 года англоканадского писателя Артура Хейли, повествующий о жизни аэропорта мегаполиса и о людях",
    //        ImageUrl = "https://cdn.f.kz/prod/449/448404_550.jpg"
    //    },
    //};
    public Book AddNewBook(string bookName, DateTime publishDate, string authorName)
    {
        var lastId = _bookRepository
            .GetAll()
            .Max(m => m.Id);

        var newBook = new Book()
        {
            Id = lastId++,
            Name = bookName,
            PublishDate = publishDate,
            AuthorName = authorName
        };

        _bookRepository.Add(newBook);
        return newBook;
    }

    public List<Book> GetBooks()
    {
        return _bookRepository.GetAll().ToList();
    }

    public Book GetBookById(int id)
    {
        return _bookRepository.GetById(id);
    }
}