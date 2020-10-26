using Hubee.Logging.Sdk.Core.Helpers;

namespace Hubee.Logging.Sdk.Core.Model
{
    public class HubeeLoggingConfig
    {
        public string ApplicationName { get; set; }
        public string LibraryType { get; set; }
        public string ProviderType { get; set; }
        public LogLibraryType LibraryTypeEnum => EnumHelper.Parse<LogLibraryType>(this.LibraryType);
        public LogProviderType ProviderTypeEnum => EnumHelper.Parse<LogProviderType>(this.ProviderType);
        public string Host { get; set; }
        public int? Port { get; set; }

        public bool IsNotValid()
        {
            return
            string.IsNullOrEmpty(this.ApplicationName) ||
            this.LibraryTypeEnum == LogLibraryType.Undefined ||
            this.ProviderTypeEnum == LogProviderType.Undefined;
        }
    }
}