using System.ComponentModel;

namespace Hubee.Logging.Sdk.Core.Model
{
    public enum LogLibraryType
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Serilog")]
        Serilog = 1
    }
}