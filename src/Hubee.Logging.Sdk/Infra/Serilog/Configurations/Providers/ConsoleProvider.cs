using Hubee.Logging.Sdk.Core.Model;
using Serilog;
using System;

namespace Hubee.Logging.Sdk.Infra.Serilog.Configurations.Providers
{
    public class ConsoleProvider : BaseProvider
    {
        public ConsoleProvider Configure(HubeeLoggingConfig config)
        {
            Log.Logger = new LoggerConfiguration()
              .Filter.ByExcluding(config.GetFilterByExcluding())
              .Enrich.WithProperty("ApplicationName", config.ApplicationName)
              .Enrich.FromLogContext()
              .Enrich.WithProperty("Timestamp", DateTimeOffset.Now) 
              .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
              .CreateLogger();

            return this;
        }
    }
}