using System.Diagnostics;
using System.IO.Pipelines;
using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CatchAll()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/{value:int}")]
        public IActionResult DefaultRoute(int value)
        {
            return Content($"The cow Default Cow moos at you {value} times.");
        }

        [Route("/EatMoreChicken")]
        public IActionResult EatMoreChicken()
        {
            return Redirect("https://www.chick-fil-a.com/");
        }

        [Route("/{value:int}/{name}")]
        public IActionResult Betsy(int value, string name)
        {
            return Content($"The cow {name} moos at you {value} times.");
        }

        [Route("/AllCows/Gallery/{value:int}")]
        public IActionResult OnThisPage(int value)
        {
            return Content($"There are {value} Cows on page.");
        }

        [Route("/AllCows/Gallery/5/Page8")]
        public IActionResult ForEveryPage()
        {
            return Content($"There are 5 cows per page, on page 8");
        }

        [Route("/AllCows/Gallery/{value1:int}/{value2:int}")]
        public IActionResult ForEveryPage(int value1, int value2)
        {
            return Content($"There are {value1} cows per page, on page {value2}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}