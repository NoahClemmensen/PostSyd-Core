using DatabaseService;
using MVC_App.Interfaces;

namespace MVC_App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var dbHost = builder.Configuration["Database:Host"];
        var dbSchema = builder.Configuration["Database:Schema"];
        var dbUser = builder.Configuration["Database:User"];
        var dbPassword = builder.Configuration["Database:Password"];
        
        if (dbHost == null || dbSchema == null || dbUser == null || dbPassword == null) 
        {
            throw new Exception("Database connection details are not configured properly.");
        }
        
        // Configure the database connection
        DatabaseConnection.Instance.SetConnectionDetails(dbHost, dbSchema, dbUser, dbPassword);

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