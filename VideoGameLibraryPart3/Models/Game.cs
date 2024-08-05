using System.ComponentModel.DataAnnotations;

namespace VideoGameLibraryPart2.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        [Required( ErrorMessage = "Title Required")]
        public string Title { get; set; }
		[Required( ErrorMessage = "Platform Required")]
		public string Platform { get; set; }
		[Required(ErrorMessage = "Genre Required")]
		public string Genre { get; set; }
		[Required(ErrorMessage = "AgeRating Required")]
		public string AgeRating { get; set; }
		[Required(ErrorMessage = "Year Required")]
		public int Year { get; set; }
        [Required(ErrorMessage = "Image Required")]
        public string Image { get; set; }
        public string? LoanedTo { get; set; } = null;
        public DateTime? LoanDate { get; set; } = null;

        // Always need an empty constructor
        public Game() { }

        public Game(string title, string platform, string genre, string ageRating, int year, string image)
        {
            Title = title;
            Platform = platform;
            Genre = genre;
            AgeRating = ageRating;
            Year = year;
            Image = image;
        }
    }
}