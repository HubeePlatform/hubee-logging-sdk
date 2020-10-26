using Xunit;

namespace Hubee.Logging.Sdk.Test.Core
{
    public class ConfigurationTest : BaseTest
    {
        [Theory]
        [InlineData("invalid_application_name", true)]
        [InlineData("invalid_library_type", true)]
        [InlineData("invalid_provider_type", true)]
        public void Should_DoNotAcceptSettings_When_Invalid(string nameSetting, bool expected)
        {
            var config = GetConfig(nameSetting, "Invalid");
            Assert.Equal(expected, config.IsNotValid());
        }

        [Theory]
        [InlineData("valid_provider_console", "serilog_console", false)]
        [InlineData("valid_provider_graylog", "serilog_graylog", false)]
        public void Should_AcceptSettings_When_valid(string nameSetting, string context, bool expected)
        {
            var config = GetConfig(nameSetting, "Valid");

            Assert.Equal(expected, config.IsNotValid());
            Assert.Equal(context, $"{config.LibraryType}_{config.ProviderType}".ToLower());
        }
    }
}