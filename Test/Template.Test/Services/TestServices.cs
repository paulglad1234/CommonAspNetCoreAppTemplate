﻿namespace Template.Test.Services;

using Template.Test.Common;
using Template.Api;
using Template.Api.Configuration;
using Template.Db.Context.Setup;
using Template.Settings;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

public class TestServices
{
    private readonly IServiceCollection services = new ServiceCollection();
    public IServiceProvider ServiceProvider { get; set; }

    public TestServices()
    {
        var configuration = ConfigurationFactory.GetApiConfiguration();

        // Logger
        var logger = new LoggerConfiguration()
            .Enrich.WithCorrelationIdHeader()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        var settings = new ApiSettings(new SettingsSource(configuration));

        services.AddHttpContextAccessor();

        services.AddAppDbContext(settings);

        services.AddAppVersions();

        services.AddAppServices();

        services.AddAppAutoMapper();

        services.AddControllers().AddValidator();

        ServiceProvider = services.BuildServiceProvider();

        DbInit.Execute(ServiceProvider);
    }

    public T Get<T>()
    {
        return ServiceProvider.GetService<T>();
    }


}
