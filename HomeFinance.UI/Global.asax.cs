using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeFinance.Core;
using HomeFinance.UI.AccountNotificatorServiceReference;
using Newtonsoft.Json;

namespace HomeFinance.UI
{
	public class WebApiApplication : HttpApplication
	{
	    protected void Application_Start()
	    {
	        JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
	        GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = serializerSettings;
	        GlobalConfiguration.Configure(WebApiConfig.Register);
	        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
	        RouteConfig.RegisterRoutes(RouteTable.Routes);
	        BundleConfig.RegisterBundles(BundleTable.Bundles);
           
	        try
	        {
                AccountNotificatorServiceClient client = new AccountNotificatorServiceClient();
                client.StartUpdateAccounts();
	        }
	        catch (Exception ex)
	        {
                TLog.Write(ex);
	        }
           
	    }
	}
}
