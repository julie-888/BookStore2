using DOTNET_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_6.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryStorage _libraryStorage;
        public LibraryController(ILibraryStorage libraryStorage)
        {
            _libraryStorage = libraryStorage;
        }
        public IActionResult Index()
        {
            var library = _libraryStorage.GetLibraryByName("Sowa");
            return View(library);
        }

        public IActionResult ReserveBook(int id)
        {
            var book = _libraryStorage.GetBookById("Sowa", id);
            return View(book);
        }

        [HttpPost]
        public IActionResult ReserveBookPost(string userName, int bookId)
        {
            _libraryStorage.ReserveBookByUser(bookId, userName, "Sowa");
            return RedirectToAction("ReservedBooks", "User", new
            {
                userName = userName
            });

        }


    }
}
