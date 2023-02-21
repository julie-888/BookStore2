using DOTNET_6.Models;
using DOTNET_6.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DOTNET_6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookStorage _bookStorage;


        public HomeController(ILogger<HomeController> logger, IBookStorage bookStorage)
        {
            _logger = logger;
            _bookStorage = bookStorage;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello form HomeController");
            var books = _bookStorage.GetBooks();
            
            ViewData["bookCollection"] = books;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}