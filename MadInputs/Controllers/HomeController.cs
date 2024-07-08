using System.Diagnostics;
using MadInputs.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadInputs.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Input()
		{
			return View();
		}

		[HttpPost]
		public IActionResult OutPut(string Input1, string Input2, string Input3, string Input4, string Input5)
		{
			ViewBag.First = Input1; 
			ViewBag.Second = Input2; 
			ViewBag.Third = Input3; 
			ViewBag.Fourth = Input4; 
			ViewBag.Fifth = Input5;

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}