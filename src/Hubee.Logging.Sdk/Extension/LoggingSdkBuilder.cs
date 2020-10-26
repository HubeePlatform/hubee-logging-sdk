using Hubee.Logging.Sdk.Core.Model;
using Hubee.Logging.Sdk.Infra.Serilog;
using Microsoft.AspNetCore.Hosting;

namespace Hubee.Logging.Sdk.Extension
{
    public static class LoggingSdkBuilder
    {
        public static IWebHostBuilder Configure(IWebHostBuilder builder, HubeeLoggingConfig config)
            => (config.LibraryTypeEnum, config.ProviderTypeEnum) switch
            {
                (LogLibraryType.Serilog, LogProviderType.Console) => new SerilogService().UseConsole(builder, config),
                (LogLibraryType.Serilog, LogProviderType.Graylog) => new SerilogService().UseGraylog(builder, config),
                (_, _) => new SerilogService().UseConsole(builder, config)
            };
    }
}