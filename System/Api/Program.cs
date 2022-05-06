using Api.Configuration;
using Serilog;
using Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((host, config) =>
{
    config
    .Enrich.WithCorrelationId()
    .ReadFrom.Configuration(host.Configuration);
});

var settings = new ApiSettings(new SettingsSource());

var services = builder.Services;
// Add services to the container.

services.AddHttpContextAccessor();

services.AddAppDbContext(settings);

services.AddAppHealthChecks();

services.AddAppVersions();

services.AddAppCors();

services.AddControllers().AddValidator();

services.AddSettings();

services.AddAppSwagger(settings);

var app = builder.Build();

app.UseAppMiddlwares();

app.UseRouting();

app.UseAppHealthChecks();

app.UseAppCors();

app.UseSerilogRequestLogging();

app.UseAppSwagger();
//app.UseAuthorization();

app.MapControllers();

app.UseAppDbContext();

app.Run();
