using System;
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
	[RoutePrefix("api/consumptions")]
	public class CostController : ApiController
	{
		private readonly ICostsService _costsService;

		public CostController(ICostsService costsService)
		{
			_costsService = costsService;
		}

		[Route("")]
		public IEnumerable<Cost> Get()
		{
			return _costsService.ReadAll();
		}

        [Route("{accountId}")]
        [HttpGet]
        public IEnumerable<Cost> GetAllByAccount(int accountId)
        {
            return _costsService.GetAllByIAccountd(accountId);
        }

		[Route("")]
		[HttpPost]
		public Cost Post([FromBody] Cost income)
		{
			IResult<Cost> result = _costsService.Create(income);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

		[Route("{consumptionId}")]
		[HttpPost]
		public Cost Update(int consumptionId, [FromBody] Cost income)
		{
			IResult<Cost> result = _costsService.Update(income);
			if (result.IsSuccess)
			{
				return result.Model;
			}
			throw new HttpResponseException(HttpStatusCode.InternalServerError);
		}

		[Route("{consumptionId}")]
		public HttpResponseMessage Delete(int consumptionId)
		{
			IResult<bool> result = _costsService.Delete(consumptionId);
			if (result.IsSuccess)
			{
				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			return new HttpResponseMessage(HttpStatusCode.InternalServerError);
		}
	}
}
