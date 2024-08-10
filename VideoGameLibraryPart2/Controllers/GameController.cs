using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Data;
using VideoGameLibraryPart2.Interfaces;
using VideoGameLibraryPart2.Models;

namespace VideoGameLibraryPart2.Controllers
{
	public class GameController : Controller
	{

		IDataAccessLayer dal;
		public GameController(IDataAccessLayer indal)
		{
			dal = indal;
		}

		// Handled in the DAL
		//
		//private static List<Game> GameList = new List<Game>
		//{
		//	new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "/images/DRG.jpg"),
		//	new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "/images/TF2.jpg"),
		//	new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "/images/BlindForest.jpg"),
		//	new Game("Ori and the Will of the Wisps", "PC", "Metroidvania", "E", 2020, "/images/WillOfTheWisps.jpg"),
		//	new Game("Lethal Company", "PC", "Horror", "Not Rated", 2023, "/images/LethalCompany.jpg")
		//};

		[HttpGet]
		public IActionResult Collection()
		{
			return View(dal.GetGames());
		}

		[HttpPost]
		public IActionResult Collection(string? endebted, int id)
		{
			Game game = dal.GetGame(id);

			if (endebted == null)
			{
				game.LoanDate = null;
			}
			else
			{
				game.LoanedTo = endebted;
				game.LoanDate = DateTime.Now;
			}
			return View(dal.GetGames());
		}

		[HttpGet]
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				ViewData["Error"] = "Game ID is Null!";
				return View();
			}
			else
			{
				Game? g = dal.GetGame((int)id);
				if (g == null)
				{
					ViewData["Error"] = "Game with ID of " + id + " was not found";
				}

				return View(g);
			}

		}

		[HttpPost]
		public IActionResult Edit(Game game)
		{
			if (ModelState.IsValid)
			{
				dal.UpdateGame(game);
				TempData["Success"] = "Updated " + game.Title.ToString() + " successfully!";
				return RedirectToAction("Collection", "Game");
			}
			else
			{
				return View();
			}


		}

		public IActionResult Delete(int id)
		{
			TempData["Success"] = dal.GetGame(id) + " was deleted!";
			dal.DeleteGame(id);
			return RedirectToAction("Collection", "Game");
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Game game)
		{
			if (ModelState.IsValid)
			{
				dal.AddGame(game);
				return RedirectToAction("Collection", "Game");
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		public IActionResult Search(string? key)
		{
			return View("Collection", dal.SearchGames(key));
		}

	}
}
