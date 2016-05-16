using System.Linq;
using System.Net;
using System.Web.Http;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Services;
using HomeFinance.UI.ActionFilters;

namespace HomeFinance.UI.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private const string Token = "Token";
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Route("current")]
        [HttpGet]
        public UserInfo GetCurrent()
        {
            if (Request.Headers.Any(x => x.Key.Equals(Token)))
            {
                string token = Request.Headers.GetValues(Token).First();
                return _usersService.GetUserByToken(token);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
