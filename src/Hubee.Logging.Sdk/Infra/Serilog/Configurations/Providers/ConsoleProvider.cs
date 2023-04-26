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
              .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
              .CreateLogger();

            return this;
        }
    }
}