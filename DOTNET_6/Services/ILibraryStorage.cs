using DOTNET_6.Models;
using DOTNET_6.Repository.FileRepositories;
using System.Xml.Linq;

namespace DOTNET_6.Services
{
    public interface ILibraryStorage
    {
        Library GetLibraryByName(string name);
        Book GetBookById(string libName, int bookId);

        Book ReserveBookByUser(int bookId, string userName, string libName);
    }

    public class LibraryStorage : ILibraryStorage
    {
        public static Library CurrentLibrary = new Library()
        {
            Name = "Sowa",
            AvailableBooks = new List<Book>()
        };

        private readonly IBookRepository _bookRepository;
        private readonly IUserStorage _userStorage;

        public LibraryStorage(IUserStorage userStorage, IBookRepository bookRepository)
        {
            _userStorage = userStorage;
            _bookRepository = bookRepository;
            CurrentLibrary.AvailableBooks = _bookRepository.GetAll().ToList();
        }

        public Library GetLibraryByName(string name)
        {
            return CurrentLibrary;
        }

        public Book GetBookById(string libName, int bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public Book ReserveBookByUser(int bookId, string userName, string libName)
        {
            var book = _bookRepository.GetById(bookId);
            var user = _userStorage.GetUserByName(userName);
            
            book.IsBooked = true;
            book.BookedBy = user;

            user.BooksToRefund.Add(book);
            _bookRepository.Update(book);
            return book;
        }
    }
}
