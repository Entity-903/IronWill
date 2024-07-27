using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Models;
using VideoGameLibraryPart2.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace VideoGameLibraryPart2.Data
{
	public class VideoGameListDAL : IDataAccessLayer
	{
		private static List<Game> GameList = new List<Game>
		{
			new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "/images/DRG.jpg"),
			new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "/images/TF2.jpg"),
			new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "/images/BlindForest.jpg"),
			new Game("Ori and the Will of the Wisps", "PC", "Metroidvania", "E", 2020, "/images/WillOfTheWisps.jpg"),
			new Game("Lethal Company", "PC", "Horror", "Not Rated", 2023, "/images/LethalCompany.jpg")
		};

		public IEnumerable<Game> GetGames()
		{
			return GameList;
		}

		public void AddGame(Game game)
		{
			GameList.Add(game);
		}

		public void DeleteGame(int id)
		{
			Game? foundGame = GetGame(id);
			if (foundGame != null) GameList.Remove(foundGame);
		}
		public Game? GetGame(int id)
		{
			Game? foundGame = GameList.Where(x => x.Id == id).FirstOrDefault();
			return foundGame;
		}
		public void UpdateGame(Game game)
		{
			int id = GameList.FindIndex(x => x.Id == game.Id);
			GameList[id] = game;
		}

		public IEnumerable<Game> SearchGames(string key)
		{
			// Returns the default list of games if key is null
			if (string.IsNullOrEmpty(key)) return GameList;
			// Otherwise, returns the list of games that contains the key within the their titles
			return GameList.Where(game => game.Title.ToLower().Contains(key.ToLower()));
		}
	}
}
