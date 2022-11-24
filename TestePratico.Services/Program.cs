using TestePratico.Application;
using TestePratico.Application.Interfaces;
using TestePratico.Data.Context;
using TestePratico.Data.Repositories;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Interfaces.Services;
using TestePratico.Domain.Services;
using TestePratico.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.EnableDetailedErrors = true;
    }
});
builder.Services.AddGrpcReflection();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IUFRepository, UFRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IUFService, UFService>();
builder.Services.AddScoped<IPessoaAppService, PessoaAppService>();
builder.Services.AddScoped<IUFAppService, UFAppService>();

builder.Services.AddDbContextPool<TestePraticoContext>(opts =>
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

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<PessoasService>();
app.MapGrpcService<UFsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
