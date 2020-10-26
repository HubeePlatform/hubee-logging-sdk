using Hubee.Logging.Sdk.Core.Model;
using Microsoft.AspNetCore.Hosting;

namespace Hubee.Logging.Sdk.Core.Interfaces
{
    public interface ILoggingService
    {
        IWebHostBuilder UseConsole(IWebHostBuilder builder, HubeeLoggingConfig config);
        IWebHostBuilder UseGraylog(IWebHostBuilder builder, HubeeLoggingConfig config);
    }
}