using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace Hubee.Logging.Sdk.Infra.Serilog.Configurations.Providers
{
    public class BaseProvider
    {
        public IWebHostBuilder UseSerilog(IWebHostBuilder builder)
        {
            builder.UseSerilog();
            return builder;
        }
    }
}