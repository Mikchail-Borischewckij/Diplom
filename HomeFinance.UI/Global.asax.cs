using System;
using System.ServiceModel;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HomeFinance.Core;
using HomeFinance.Host1;
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

            //Thread thread = new Thread(() =>
            //{

            //    var myBinding = new BasicHttpBinding();
            //    var myEndpoint = new EndpointAddress("http://localhost/Host/IAccountNotificatorService.svc");
            //    var myChannelFactory = new ChannelFactory<IAccountNotificatorService>(myBinding, myEndpoint);


            //    IAccountNotificatorService client = null;

            //    try
            //    {
            //        TLog.Write("WCF");
            //        client = myChannelFactory.CreateChannel();
            //        client.StartUpdateAccounts();
            //    }
            //    catch (Exception ex)
            //    {
            //        TLog.Write(ex.Message);
            //        if (client != null)
            //        {
            //            ((ICommunicationObject)client).Abort();
            //        }
            //    }
            //});
            //thread.Start();

	    }
	}
}
