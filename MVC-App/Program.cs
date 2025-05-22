using DatabaseService;
using MVC_App.Interfaces;
using MVC_App.Services;

namespace MVC_App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var dbHost = builder.Configuration["Database:Host"];
        var dbSchema = builder.Configuration["Database:Schema"];
        var selectUser = builder.Configuration["Database:Select:User"];
        var selectPassword = builder.Configuration["Database:Select:Password"];
        var execUser = builder.Configuration["Database:Exec:User"];
        var execPassword = builder.Configuration["Database:Exec:Password"];
        
        if (dbHost == null || dbSchema == null || selectUser == null || selectPassword == null || execUser == null || execPassword == null) 
        {
            throw new Exception("Database connection details are not configured properly.");
        }
        
        // Configure the database connection
        DatabaseConnection.SelectInstance.SetConnectionDetails(dbHost, dbSchema, selectUser, selectPassword);
        DatabaseConnection.ExecInstance.SetConnectionDetails(dbHost, dbSchema, execUser, execPassword);
        
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<IDatabaseService, Services.DatabaseService>();
        builder.Services.AddSingleton<IPackageRoutingService, PackageRoutingService>();
        builder.Services.AddSingleton<IMqttService, MqttService>();
        builder.Services.AddHostedService<MqttHostedService>();
        builder.Services.AddTransient<OcrMessageProcessor>();

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