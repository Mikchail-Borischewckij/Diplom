using System.Configuration;

namespace HomeFinance.UI.Configuration.HostsConfiguration
{
    public class HostsElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HostsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HostsElement)element).Name;
        }

        public HostsElement this[int index]
        {
            get { return (HostsElement)BaseGet(index); }
        }

        public new HostsElement this[string name]
        {
            get { return (HostsElement)BaseGet(name); }
        }
    }
}