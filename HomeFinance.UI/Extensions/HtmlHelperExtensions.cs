using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HomeFinance.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string RequestVerificationToken(this HtmlHelper helper)
        {
            return string.Format("ncg-request-verification-token={0}", GetAntiForgeryToken());
        }

        private static string GetAntiForgeryToken()
        {
            string cookieToken, formToken;
            AntiForgery.GetTokens(null, out cookieToken, out formToken);
            return cookieToken + ":" + formToken;
        }
    }
}