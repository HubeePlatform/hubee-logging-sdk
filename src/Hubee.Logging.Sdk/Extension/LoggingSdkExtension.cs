using Hubee.Logging.Sdk.Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace Hubee.Logging.Sdk.Extension
{
    public static class LoggingSdkExtension
    {
        public static IWebHostBuilder UseHubeeLogging(this IWebHostBuilder builder, IConfigurationRoot configurationSection)
        {
            var loggingConfig = new HubeeLoggingConfig();
            configurationSection.GetSection("HubeeLoggingConfig").Bind(loggingConfig);

            if (loggingConfig.IsNotValid())
                throw new InvalidOperationException($"Please, configure appsettings with a {nameof(HubeeLoggingConfig)} section");

            LoggingSdkBuilder.Configure(builder, loggingConfig);

            return builder;
        }
    }
}