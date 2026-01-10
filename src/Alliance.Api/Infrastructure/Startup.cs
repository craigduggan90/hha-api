using Alliance.Api.Infrastructure.Configuration;
using Alliance.Api.Infrastructure.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Serilog.Filters;
using System.Globalization;

namespace Alliance.Api.Infrastructure;

public static class Startup
{
    public static WebApplicationBuilder ConfigureServer(this WebApplicationBuilder builder)
    {
        var serverConfiguration = new ServerConfiguration();
        builder.Configuration.GetSection("Server").Bind(serverConfiguration);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Logger(logger => logger
                .Filter.ByExcluding(Matching.FromSource<RequestLoggingMiddleware>())
                .WriteTo.Console(
                    formatProvider: CultureInfo.InvariantCulture,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"))
            .WriteTo.Logger(logger => logger
                .Filter.ByIncludingOnly(Matching.FromSource<RequestLoggingMiddleware>())
                .WriteTo.File(
                    path: serverConfiguration.LogFilePath,
                    formatProvider: CultureInfo.InvariantCulture,
                    outputTemplate: "{Timestamp:HH:mm:ss} {Message:lj}{NewLine}"))
            .CreateLogger();
        
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog();
        
        builder.WebHost.UseKestrel(options =>
        {
            options.ListenAnyIP(serverConfiguration.Port);
        });

        // Register the redaction settings from config
        builder.Services.Configure<RedactionConfiguration>(builder.Configuration.GetSection("Redaction"));
        builder.Services.AddSingleton<RedactionConfiguration>(sp =>
            sp.GetRequiredService<IOptions<RedactionConfiguration>>().Value);
        
        return builder;
    }
}