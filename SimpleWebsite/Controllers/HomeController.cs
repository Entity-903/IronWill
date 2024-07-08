using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleWebsite.Models;

namespace SimpleWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult General()
        {
            return View();
        }

        public IActionResult Lore()
        {
            return View();
        }

        public IActionResult Expectations()
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