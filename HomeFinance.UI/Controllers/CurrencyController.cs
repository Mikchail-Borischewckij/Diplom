using System.Collections.Generic;
using System.Web.Http;
using HomeFinance.Contract.Data;
using HomeFinance.Services;
using HomeFinance.UI.ActionFilters;

namespace HomeFinance.UI.Controllers
{
    //[AuthorizationRequired]
	[RoutePrefix("api/currency")]
	public class CurrencyController : ApiController
	{
		private readonly ICurrencyService _currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			_currencyService = currencyService;
		}

		[Route("")]
		[HttpGet]
		public IEnumerable<Currency> GetCurrencies()
		{
			return _currencyService.ReadAll();
		}

        [Route("current")]
        [HttpGet]
        public IEnumerable<Currency> GetCurrentCurrenciesValues()
        {
            return _currencyService.GetCurrentCurrenciesValues();
        }
	}
}
