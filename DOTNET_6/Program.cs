using DOTNET_6.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DOTNET_6.Data;
using DOTNET_6.Models;
using DOTNET_6.Services;
using DOTNET_6.Repository.FileRepositories;
using DOTNET_6.EntityFramework;
using DOTNET_6.Repository.EntityFrameworkRepositories;

namespace DOTNET_6
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options
                    .UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnectionString")));

            //builder.Services.AddSingleton<IBookRepository, FileBookRepository>(
            //    provider =>
            //    {
            //        var instance = new FileBookRepository("BooksJson.json");
            //        return instance;
            //    }
            //    );
            builder.Services.AddSingleton<IBookRepository, EfCoreBookRepository>();

            builder.Services.AddSingleton<ILibraryStorage, LibraryStorage>();
            builder.Services.AddSingleton<IBookStorage, BookStorage>();
            builder.Services.AddSingleton<IUserStorage, UserStorage>();


            builder.Services.AddBookStorage();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            await app.RunAsync();
        }
    }
}