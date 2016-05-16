using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Services;
using HomeFinance.UI.ActionFilters;

namespace HomeFinance.UI.Controllers
{
	[AuthorizationRequired]
	[RoutePrefix("api/account")]
	public class AccountController : ApiController
	{
		private readonly IAccountsService _accountsService;

		public AccountController(IAccountsService accountsService)
		{
			_accountsService = accountsService;
		}

        [HttpGet]
        [Route("{userId}")]
        public Account Read(int userId)
        {
            return _accountsService.Read(userId);
        }

        [HttpGet]
		[Route("all/{userId}")]
		public IEnumerable<Account> GetAllByUser(int userId)
		{
			return _accountsService.AllByUserId(userId);
		}

        [HttpPost]
        [Route("")]
		public Account Post([FromBody] Account account)
		{
			IResult<Account> result = _accountsService.Create(account);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

        [HttpPost]
        [Route("{accountId}")]
        public Account Post(int accountId, [FromBody] Account account)
		{
			IResult<Account> result = _accountsService.Update(account);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

        [Route("{accountId}")]
        public HttpResponseMessage Delete(int accountId)
		{
            IResult<bool> result = _accountsService.Delete(accountId);
			if (result.IsSuccess)
			{
				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}

	}
}
