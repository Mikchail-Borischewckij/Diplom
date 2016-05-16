using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeFinance.Host;
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
      }

	}
}
