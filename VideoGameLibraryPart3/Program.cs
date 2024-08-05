namespace VideoGameLibraryPart2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Welcome}/{id?}");

			app.Run();
		}
	}
}

// For whatever reason, the project makes no changes when I say to replace
// VideoGameLibraryPart2
//         with
// VideoGameLibraryPart3
// within the entire, current, project