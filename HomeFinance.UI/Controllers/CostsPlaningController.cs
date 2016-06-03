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
    [RoutePrefix("api/cotsPlaning")]
    public class CostsPlaningController : ApiController
    {
        private readonly ICostsPlaningService _costsPlaningService;

        public CostsPlaningController(ICostsPlaningService costsPlaningService)
        {
            _costsPlaningService = costsPlaningService;
        }

        [Route("{accountId}/{month}")]
        public IEnumerable<CostsPlaning> Get(int accountId, int month)
        {
            return _costsPlaningService.ByAccountIdAndMonth(accountId, month);
        }

        [Route("")]
        [HttpPost]
        public CostsPlaning Post([FromBody] CostsPlaning item)
        {
            IResult<CostsPlaning> result = _costsPlaningService.Create(item);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{itemId}")]
        [HttpPost]
        public CostsPlaning Update(int itemId, [FromBody] CostsPlaning item)
        {
            IResult<CostsPlaning> result = _costsPlaningService.Update(item);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{itemId}")]
        public HttpResponseMessage Delete(int itemId)
        {
            IResult<bool> result = _costsPlaningService.Delete(itemId);
            if (result.IsSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [Route("{accountId}")]
        public IEnumerable<int> GetPlaningMonths(int accountId)
        {
            return _costsPlaningService.ByMonthsByAccountId(accountId);
        }

    }
}