using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SendThreeWays.Models;

namespace SendThreeWays.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult AlternateViews()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult RouteTest(int? id)
		{
			return Content($"id = {id?.ToString() ?? "NULL"}");
		}

		public IActionResult ParamTest(int? id, string s)
		{
			return Content($"id = {id?.ToString() ?? "NULL"} {s}");
			//id? = nullable variable
			//?? = null coalsescing operator.  if variable is true do left, else do right
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}