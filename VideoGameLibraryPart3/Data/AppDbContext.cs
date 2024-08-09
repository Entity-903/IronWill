using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameLibraryPart2.Models;

namespace VideoGameLibraryPart3.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<Game> Games { get; set; }

		public IActionResult Index()
		{
			return null;
		}
	}
}
