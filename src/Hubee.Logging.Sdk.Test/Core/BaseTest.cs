using Hubee.Logging.Sdk.Core.Model;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Hubee.Logging.Sdk.Test.Core
{
    public class BaseTest
    {
        private static IConfiguration GetConfiguration(string nameSetting, string path = "")
        {
            return new ConfigurationBuilder()
                  .SetBasePath($"{Directory.GetCurrentDirectory()}\\Core\\Settings\\{path}")
                  .AddJsonFile($"{nameSetting}.json")
                  .Build();
        }

        public HubeeLoggingConfig GetConfig(string nameSetting, string path = "")
        {
            var configuration = GetConfiguration(nameSetting, path);
            var stoneConfig = new HubeeLoggingConfig();
            configuration.GetSection("HubeeLoggingConfig").Bind(stoneConfig);

            return stoneConfig;
        }
    }
}