using Hubee.Logging.Sdk.Core.Interfaces;
using Hubee.Logging.Sdk.Core.Model;
using Hubee.Logging.Sdk.Infra.Serilog.Configurations.Providers;
using Microsoft.AspNetCore.Hosting;

namespace Hubee.Logging.Sdk.Infra.Serilog
{
    public class SerilogService : ILoggingService
    {
        public IWebHostBuilder UseConsole(IWebHostBuilder builder, HubeeLoggingConfig config)
        {
            return new ConsoleProvider().Configure(config).UseSerilog(builder);
        }

        public IWebHostBuilder UseGraylog(IWebHostBuilder builder, HubeeLoggingConfig config)
        {
            return new GraylogProvider().Configure(config).UseSerilog(builder);
        }
    }
}