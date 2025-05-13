using DatabaseService;
using MVC_App.Interfaces;

namespace MVC_App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Configure the database connection
        DatabaseConnection.Instance.SetConnectionDetails("10.130.56.30","postsyd", "admin", "stikadmin1bajer"); // Use .env

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IDatabaseService, Services.DatabaseService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}