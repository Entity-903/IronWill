using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Data;
using VideoGameLibraryPart2.Interfaces;
using VideoGameLibraryPart2.Models;

namespace VideoGameLibrary.Controllers
{
	public class GameController : Controller
	{

		IDataAccessLayer dal = new VideoGameListDAL();

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

	}
}
