namespace VideoGameLibrary.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        public string Title { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public string AgeRating { get; set; }
        public int Year { get; set; }
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
