using Microsoft.EntityFrameworkCore;
using TestePratico.Application;
using TestePratico.Application.Interfaces;
using TestePratico.Data.Context;
using TestePratico.Data.Repositories;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        #region DI setup
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
        builder.Services.AddScoped<IUFRepository, UFRepository>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IUFService, UFService>();
        builder.Services.AddScoped<IPersonAppService, PersonAppService>();
        builder.Services.AddScoped<IUFAppService, UFAppService>();

        builder.Services.AddDbContext<TestePraticoContext>(opts =>
        {
            opts.UseMySql(
                builder.Configuration.GetConnectionString("TestePraticoContext"),
                new MySqlServerVersion(new Version(8, 0, 28))
            );

            if (builder.Environment.IsDevelopment())
            {
                opts.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            }
        });
        #endregion

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
