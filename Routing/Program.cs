namespace Routing
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
                pattern: "{controller=Home}/{action=Privacy}/{id?}");

            app.MapControllerRoute(
                name: "CatchAll",
                pattern: "{*any}",
                defaults: new { controller = "Home", action = "CatchAll"});

            //app.MapControllerRoute(
            //    name: "DefaultRoute",
            //    pattern: "/{id:int}",
            //    defaults: new { controller = "Home", action = "DefaultRoute"});












            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Privacy}/{id?}");

            app.Run();
        }
    }
}