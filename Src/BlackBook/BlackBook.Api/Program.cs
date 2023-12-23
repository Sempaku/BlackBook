using BlackBook.Data;
using BlackBook.Data.Interfaces;
using BlackBook.Data.Repository;
using BookStorageService;
using Mega.Client;
using MegaService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RatingService;
using System;
using System.Diagnostics;
using UserBookProgressService;

namespace BlackBook.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

#if DEBUG
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            Console.WriteLine("DEBUG configuration is active!");
#endif
#if RELEASE
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql("Host=amvera-sempaku-run-pg-blackbook;Port=5432;Database=bb_test_db;Username=postgres;Password=2003;");
            });
            Console.WriteLine("RELEASE configuration is active!");

#endif

            builder.Services.AddSingleton<IMegaClient, MegaClient>();
            builder.Services.AddSingleton<IMegaService, MegaService.MegaService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookFileRepository, BookFileRepository>();
            builder.Services.AddScoped<IUserBookProgressRepository, UserBookProgressRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();
            builder.Services.AddScoped<IBookStorageService, BookStorageService.BookStorageService>();
            builder.Services.AddScoped<IRatingService, RatingService.RatingService>();
            builder.Services.AddScoped<IUserBookProgressService, UserBookProgressService.UserBookProgressService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();
            app.Run();
        }
    }
}