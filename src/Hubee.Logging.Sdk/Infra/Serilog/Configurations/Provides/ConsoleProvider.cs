using Hubee.Logging.Sdk.Core.Model;
using Serilog;

namespace Hubee.Logging.Sdk.Infra.Serilog.Configurations.Provides
{
    public class ConsoleProvider : BaseProvider
    {
        public ConsoleProvider Configure(HubeeLoggingConfig config)
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.WithProperty("ApplicationName", config.ApplicationName)
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            return this;
        }
    }
}