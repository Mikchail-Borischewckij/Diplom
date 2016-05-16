using System.Configuration;

namespace HomeFinance.UI.Configuration.HostsConfiguration
{
    public class HostsElement : ConfigurationElement
    {
        private const string HostsConfigurationPropertyName = "name";
        private const string UrlConfigurationPropertyName = "url";

        [ConfigurationProperty(HostsConfigurationPropertyName, IsRequired = true)]
        public string Name
        {
            get { return (string)base[HostsConfigurationPropertyName]; }
            set { base[HostsConfigurationPropertyName] = value; }
        }

        [ConfigurationProperty(UrlConfigurationPropertyName, IsRequired = true)]
        public string Url
        {
            get { return (string)base[UrlConfigurationPropertyName]; }
            set { base[UrlConfigurationPropertyName] = value; }
        }
    }
}