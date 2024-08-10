using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Models;
using VideoGameLibraryPart2.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;


namespace VideoGameLibraryPart2.Data
{
	public class VideoGameListDAL : IDataAccessLayer
	{
		private AppDbContext db;

		public VideoGameListDAL(AppDbContext indb)
		{
			db = indb;
		}

		//private static List<Game> GameList = new List<Game>
		//{
		//	new Game("Deep Rock Galactic", "PC", "FPS", "T", 2020, "/images/DRG.jpg"),
		//	new Game("Team Fortress 2", "PC", "FPS", "M", 2007, "/images/TF2.jpg"),
		//	new Game("Ori and the Blind Forest", "PC", "Metroidvania", "E", 2015, "/images/BlindForest.jpg"),
		//	new Game("Ori and the Will of the Wisps", "PC", "Metroidvania", "E", 2020, "/images/WillOfTheWisps.jpg"),
		//	new Game("Lethal Company", "PC", "Horror", "Not Rated", 2023, "/images/LethalCompany.jpg")
		//};

/*		For VideoGameLibrary Database:		
		INSERT INTO Games(Title, Platform, Genre, AgeRating, Year, Image)
		Values('Deep Rock Galactic', 'PC', 'FPS', 'T', '2020', '/images/DRG.jpg')
		Go
		INSERT INTO Games(Title, Platform, Genre, AgeRating, Year, Image)
		Values('Team Fortress 2', 'PC', 'FPS', 'M', '2007', '/images/TF2.jpg')
		Go
		INSERT INTO Games(Title, Platform, Genre, AgeRating, Year, Image)
		Values('Ori and the Blind Forest', 'PC', 'Metroidvania', 'E', '2015', '/images/BlindForest.jpg')
		Go
		INSERT INTO Games(Title, Platform, Genre, AgeRating, Year, Image)
		Values('Ori and the Will of the Wisps', 'PC', 'Metroidvania', 'E', '2020', '/images/WillOfTheWisps.jpg')
		Go
		INSERT INTO Games(Title, Platform, Genre, AgeRating, Year, Image)
		Values('Deep Rock Galactic', 'PC', 'Horror', 'Not Rated', '2023', '/images/DRG.jpg')
		Go
*/

		public IEnumerable<Game> GetGames()
		{
			return db.Games;
		}

		public void AddGame(Game game)
		{
			db.Games.Add(game);
			db.SaveChanges();
		}

		public void DeleteGame(int id)
		{
			Game? foundGame = GetGame(id);
			if (foundGame != null) db.Games.Remove(foundGame);
			db.SaveChanges();
		}
		public Game? GetGame(int id)
		{
			Game? foundGame = db.Games.Where(x => x.Id == id).FirstOrDefault();
			return foundGame;
		}
		public void UpdateGame(Game game)
		{
			Game targetGame = (Game)db.Games.Where(x => x.Id == game.Id); //FindIndex(x => x.Id == game.Id);
			targetGame = game;
			db.SaveChanges();
		}

		public IEnumerable<Game> SearchGames(string key)
		{
			// Returns the default list of games if key is null
			if (string.IsNullOrEmpty(key)) return db.Games;
			// Otherwise, returns the list of games that contains the key within the their titles
			return db.Games.Where(game => game.Title.ToLower().Contains(key.ToLower()));
		}

		public IEnumerable<Game> FilterGames(string genre, string platform, string ageRating)
		{
			IEnumerable<Game> GamesByGenre = GetGames()
				.Where(g => g.Genre.ToLower().Contains(genre.ToLower())).ToList();

			IEnumerable<Game> GamesByPlatform = GetGames()
				.Where(g => g.Platform.ToLower().Contains(platform.ToLower())).ToList();

			IEnumerable<Game> GamesByAgeRating = GetGames()
				.Where(g => g.AgeRating.ToLower().Contains(ageRating.ToLower())).ToList();

			return GamesByGenre.Intersect(GamesByPlatform.Intersect(GamesByAgeRating));
		}
	}
}
