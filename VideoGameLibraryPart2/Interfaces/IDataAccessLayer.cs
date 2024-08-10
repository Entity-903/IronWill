using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Models;

namespace VideoGameLibraryPart2.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Game> GetGames();
		IEnumerable<Game> SearchGames(string key);
		void AddGame(Game game);
		void UpdateGame(Game game);
		void DeleteGame(int id);
		Game? GetGame(int id);

		IEnumerable<Game> FilterGames(string genre, string platform, string ageRating);
	}
}
