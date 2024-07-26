using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using VideoGameLibraryPart2.Models;

namespace VideoGameLibraryPart2.Interfaces
{
	public interface IDataAccessLayer
	{
		IEnumerable<Game> GetGames();
		void AddGame(Game game);
		void RemoveGame(int id);
		Game? GetGame(int id);
		void UpdateGame(Game game);
	}
}
