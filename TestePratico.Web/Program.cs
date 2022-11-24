using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Web.AspNetCore;
using TestePratico.Application;
using TestePratico.Application.Interfaces;
using TestePratico.Commom.Ninject;
using TestePratico.Data.Context;
using TestePratico.Data.Repositories;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        // var hostConfiguration = new AspNetCoreHostConfiguration(args)
        //         .UseStartup<Startup>()
        //         .UseKestrel()
        //         .BlockOnStart();

        // var host = new NinjectSelfHostBootstrapper(CreateKernel, hostConfiguration);
        // host.Start();

        // return;


        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddNinject(CreateKernel());

        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
        builder.Services.AddScoped<IUFRepository, UFRepository>();
        builder.Services.AddScoped<IPessoaService, PessoaService>();
        builder.Services.AddScoped<IUFService, UFService>();
        builder.Services.AddScoped<IPessoaAppService, PessoaAppService>();
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

    public static AspNetCoreKernel CreateKernel()
    {
        var settings = new NinjectSettings();
        // Unfortunately, in .NET Core projects, referenced NuGet assemblies are not copied to the output directory
        // in a normal build which means that the automatic extension loading does not work _reliably_ and it is
        // much more reasonable to not rely on that and load everything explicitly.
        //settings.LoadExtensions = false;

        var kernel = new AspNetCoreKernel(settings);
        //kernel.DisableAutomaticSelfBinding();

        //kernel.Load(typeof(AspNetCoreHostConfiguration).Assembly);
        kernel.Load(Assembly.GetExecutingAssembly());
        kernel.Load(ModuleHelper.GetModules());

        kernel.Bind<Lazy<IModelMetadataProvider>>().ToMethod(x =>
             new Lazy<IModelMetadataProvider>(() => x.Kernel.Get<IModelMetadataProvider>()));

        // kernel.Bind<HomeController>().ToSelf().InRequestScope();
        // kernel.Bind<PessoasController>().ToSelf().InRequestScope();
        // kernel.Bind<UFsController>().ToSelf().InRequestScope();

        return kernel;
    }
}
