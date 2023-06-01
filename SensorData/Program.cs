/// <summary>
/// 
/// This project has the intent to collect data regarding soil moisture from a LoRaWAN implemented 
/// in a farm of experimental cocoa crop.
/// 
/// Author: Alexandre Cavalcanti
/// Date: 05/31/2023
/// 
/// </summary>

using Microsoft.EntityFrameworkCore;
using SensorData.Models;


namespace SensorData
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connStr = builder.Configuration.GetConnectionString("postgres");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SensorContext>(options => options.UseNpgsql(connStr));                                      //"Host=localhost;Port=5432;Pooling=true;Database=postgres;User Id=postgres;Password=Pg3202pG;"));

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
            app.UseAuthentication();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}