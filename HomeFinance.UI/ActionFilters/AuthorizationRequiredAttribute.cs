using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using HomeFinance.Contract;
using HomeFinance.Services;

namespace HomeFinance.UI.ActionFilters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";

	    public override void OnActionExecuting(HttpActionContext filterContext)
	    {
		    //  Get API key provider
		    ITokenServices provider = filterContext.ControllerContext.Configuration
			    .DependencyResolver.GetService(typeof (ITokenServices)) as ITokenServices;

		    if (provider == null)
		    {
			    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			    base.OnActionExecuting(filterContext);
			    return;
		    }

		    if (filterContext.Request.Headers.Contains(Token))
		    {
			    string tokenValue = filterContext.Request.Headers.GetValues(Token).First();
			    IResult<bool> result = provider.ValidateToken(tokenValue);
			    if (!result.IsSuccess)
			    {
				    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			    }
		    }
		    else
		    {
			    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
		    }

		    base.OnActionExecuting(filterContext);
	    }
    }
}