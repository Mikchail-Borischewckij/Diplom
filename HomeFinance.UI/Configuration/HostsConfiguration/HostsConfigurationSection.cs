using System.Configuration;

namespace HomeFinance.UI.Configuration.HostsConfiguration
{
    public class HostsConfigurationSection : ConfigurationSection
    {
        private const string CollectionName = "endpoints";
        public const string SectionName = "hosts";

        /// <summary>
        /// Gets section name
        /// </summary>
        public string Name
        {
            get { return SectionName; }
        }

        public static HostsConfigurationSection GetSection()
        {
            return (HostsConfigurationSection)ConfigurationManager.GetSection(SectionName) ?? new HostsConfigurationSection();
        }

        [ConfigurationProperty(CollectionName)]
        [ConfigurationCollection(typeof(HostsElement))]
        public HostsElementCollection Hosts
        {
            get
            {
                return (HostsElementCollection)base[CollectionName];
            }
        }
    }
}