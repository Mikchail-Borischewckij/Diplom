using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeFinance.Host1;
using Newtonsoft.Json;

namespace HomeFinance.UI
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = serializerSettings;
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var myBinding = new BasicHttpBinding();
			var myEndpoint = new EndpointAddress("http://localhost:3789/AccountNotificatorService.svc");
			var myChannelFactory = new ChannelFactory<IAccountNotificatorService>(myBinding, myEndpoint);

			IAccountNotificatorService client = null;

			try
			{
				client = myChannelFactory.CreateChannel();
				client.UpdataAccounts();
				((ICommunicationObject)client).Close();
			}
			catch
			{
				if (client != null)
				{
					((ICommunicationObject)client).Abort();
				}
			}

      }

	}
}
