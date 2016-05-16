using System.Web.Http;
using HomeFinance.Data;
using HomeFinance.Data.Impl;
using HomeFinance.Services;
using HomeFinance.Services.Impl;
using HomeFinance.UI.IoC;
using Microsoft.Practices.Unity;

namespace HomeFinance.UI
{
    public static class ContainerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            Bootstrapper.InitializeContainer(container);
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}