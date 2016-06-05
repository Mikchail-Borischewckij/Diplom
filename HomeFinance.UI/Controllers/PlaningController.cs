using System;
using System.Net;
using System.Web.Http;
using HomeFinance.Services;

namespace HomeFinance.UI.Controllers
{
    [RoutePrefix("api/planing")]
    public class PlaningController : ApiController
    {
        private readonly IPlaningService _planingService;

        public PlaningController(IPlaningService planingService)
        {
            _planingService = planingService;
        }

        [HttpGet]
        [Route("{accountId}")]
        public double GetAverageBalanceByIAccountd(int accountId)
        {
            double value = _planingService.GetAverageBalanceByAccountd(accountId);
            if (Math.Abs(value) <= 0 || Double.IsNaN(value))
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            return value;
        }
    }
}