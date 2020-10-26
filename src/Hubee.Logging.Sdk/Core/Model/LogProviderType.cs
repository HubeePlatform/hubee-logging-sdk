using System.ComponentModel;

namespace Hubee.Logging.Sdk.Core.Model
{
    public enum LogProviderType
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Console")]
        Console = 1,
        [Description("Graylog")]
        Graylog = 2
    }
}