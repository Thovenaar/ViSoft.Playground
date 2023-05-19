using ViSoft.Playground.Application;
using ViSoft.Playground.Persistence.EF;
using ViSoft.Playground.WebAPI.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .AddControllersAsServices();

builder.Services
    .RegisterApiVersioning()
    .AddApplicationInsightsTelemetry()
    .RegisterApplicationLayer()
    .RegisterPersistenceLayer(builder.Configuration);

var app = builder.Build();
app.MapControllers();
app.RegisterApiVersioning();
app.UseHttpsRedirection();
app.Run();