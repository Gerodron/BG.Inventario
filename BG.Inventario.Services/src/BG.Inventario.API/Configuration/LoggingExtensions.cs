using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

namespace BG.Inventario.API.Configuration
{
    public static class LoggingExtensions
    {
        public static WebApplicationBuilder AddSerilogLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();

            builder.Host.UseSerilog((context, services, loggerConfiguration) =>
            {
                loggerConfiguration
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .Filter.ByExcluding(logEvent =>
                    {
                        if (!logEvent.Properties.TryGetValue("RequestPath", out var pathValue))
                        {
                            return false;
                        }

                        var path = pathValue.ToString().Trim('"');
                        return path.StartsWith("/health")
                               || path.StartsWith("/swagger")
                               || path.StartsWith("/favicon.ico");
                    })
                    .Filter.ByExcluding(logEvent =>
                        logEvent.MessageTemplate.Text.Contains(
                            "No store type was specified for the decimal property",
                            StringComparison.OrdinalIgnoreCase))
                    //.WriteTo.Console()
                    .WriteTo.File(
                        path: Path.Combine("Logs", "BG.Inventario-.log"),
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}");
            });

            return builder;
        }
    }
}
