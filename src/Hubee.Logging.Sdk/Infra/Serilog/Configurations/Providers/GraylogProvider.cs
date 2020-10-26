using Hubee.Logging.Sdk.Core.Model;
using Serilog;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace Hubee.Logging.Sdk.Infra.Serilog.Configurations.Providers
{
    public class GraylogProvider : BaseProvider
    {
        const int defaultPort = 12201;

        public GraylogProvider Configure(HubeeLoggingConfig config)
        {
            var port = config.Port is null ? defaultPort : config.Port;

            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .Enrich.WithProperty("ApplicationName", config.ApplicationName)
              .WriteTo.Console()
              .WriteTo.Graylog(new GraylogSinkOptions()
              {
                  HostnameOrAddress = config.Host,
                  Port = port,
                  TransportType = TransportType.Udp
              })
              .CreateLogger();

            return this;
        }
    }
}