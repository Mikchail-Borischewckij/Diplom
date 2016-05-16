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
	[RoutePrefix("api/incomes")]
	public class IncomeController : ApiController
	{
		private readonly IIncomeService _incomeService;

		public IncomeController(IIncomeService incomeService)
		{
			_incomeService = incomeService;
		}

		[Route("")]
		public IEnumerable<Income> Get()
		{
			return _incomeService.ReadAll();
		}
       
        [Route("{accountId}")]
        [HttpGet]
        public IEnumerable<Income> GetAllByAccount(int accountId)
        {
            return _incomeService.GetAllByIAccountd(accountId);
        }

		[Route("")]
		[HttpPost]
		public Income Post([FromBody] Income income)
		{
			IResult<Income> result = _incomeService.Create(income);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

		[Route("{incomeId}")]
		[HttpPost]
		public Income Update(int incomeId, [FromBody] Income income)
		{
			IResult<Income> result = _incomeService.Update(income);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

		[Route("{incomeId}")]
		public HttpResponseMessage Delete(int incomeId)
		{
			IResult<bool> result = _incomeService.Delete(incomeId);
			if (result.IsSuccess)
			{
				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}

	}
}
