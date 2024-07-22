using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Input(UserInput userInput)
		{
            // Check joint nullable for Address fields
            if ((userInput.Street == null && userInput.City == null && userInput.State == null && userInput.ZipCode == null) ||
				(userInput.Street != null && userInput.City != null && userInput.State != null && userInput.ZipCode != null))
            {
                if (ModelState.IsValid) 
                { 
                    return RedirectToAction("Output", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("ZipCode", "Address cannot be incomplete!");
            }

			return View();
		}

		public IActionResult Output()
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