using TestPryaniky.API;
using TestPryaniky.Application;
using TestPryaniky.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddInfrastructureServices(configuration)
    .AddApplicationServices(configuration)
    .AddApiServices(configuration);

var app = builder.Build();

await app.UseApiServices();

app.Run();
