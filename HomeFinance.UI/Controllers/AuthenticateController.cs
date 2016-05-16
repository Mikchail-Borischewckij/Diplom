using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HomeFinance.Contract;
using HomeFinance.Contract.Authorization;
using HomeFinance.Core;
using HomeFinance.Services;

namespace HomeFinance.UI.Controllers
{
	[RoutePrefix("api/authenticate")]
	public class AuthenticateController : ApiController
	{
        private const string Token = "Token";
		private readonly ITokenServices _tokenServices;
		private readonly IAuthenticateService _usersService;

		public AuthenticateController(ITokenServices tokenServices, IAuthenticateService usersService)
		{
			_tokenServices = tokenServices;
			_usersService = usersService;
		}

		[Route("login")]
		[HttpPost]
		public HttpResponseMessage Authenticate([FromBody] User user)
		{
			User current = _usersService.Authenticate(user);
			if (current != null)
			{
				return GetAuthToken(current.Id);
			}
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}

		[Route("register")]
	    [HttpPost]
	    public HttpResponseMessage Register([FromBody] User user)
	    {
	        User current = _usersService.Register(user);
            if (current != null)
	        {
                return GetAuthToken(current.Id);
	        }

	        return new HttpResponseMessage(HttpStatusCode.InternalServerError);
	    }

	    [Route("validateToken")]
	    [HttpGet]
	    public HttpResponseMessage ValidateToken()
	    {
	        if (Request.Headers.Any(x => x.Key.Equals(Token)))
	        {
	            string token = Request.Headers.GetValues(Token).First();
	            IResult<bool> result = _tokenServices.ValidateToken(token);
	            if (result.IsSuccess)
	            {
	                return new HttpResponseMessage(HttpStatusCode.OK);
	            }
	        }
	        return new HttpResponseMessage(HttpStatusCode.InternalServerError);
	    }

	    [NonAction]
		private HttpResponseMessage GetAuthToken(int userId)
		{
			IResult<Token> result = _tokenServices.GenerateToken(userId);
			if (result.IsSuccess)
			{
				Token token = result.Model;
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
				response.Headers.Add("Token", token.AuthToken);
				response.Headers.Add("TokenExpiry", AppSetting.AuthTokenExpiry.ToString());
				response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
				return response;
			}
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}
	}
}
