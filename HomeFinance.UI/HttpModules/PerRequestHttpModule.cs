using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeFinance.UI.Properties;

namespace HomeFinance.UI.HttpModules
{
    public class PerRequestHttpModule : IHttpModule
    {
        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="HttpApplication"/> that provides access to the methods, properties,
        /// and events common to all application objects within an ASP.NET application.</param>
        public void Init(HttpApplication context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("HTTP context");
            }
            context.EndRequest += (sender, e) => InterceptorError(((HttpApplication)sender).Context);
        }

        private void InterceptorError(HttpContext context)
        {
            const int HttpStatusCodeRedirect = 302;
            const int HttpStatusCodeOk = 200;

            int statusCode = context.Response.StatusCode;
            if (statusCode != HttpStatusCodeOk && statusCode != HttpStatusCodeRedirect)
            {
                context.Response.Clear();
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.Write(Resources.Error);
            }
        }

        /// <summary>
        /// Disposes the resources used by this module.
        /// </summary>
        public void Dispose()
        {
        }
    }
}