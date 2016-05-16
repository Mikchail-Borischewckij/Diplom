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
   [RoutePrefix("api/incomePlaning")]
    public class IncomePlaningController : ApiController
    {
       private readonly IIncomePlaningService _incomePlaningService;

        public IncomePlaningController(IIncomePlaningService incomePlaningService)
        {
            _incomePlaningService = incomePlaningService;
        }

        [Route("{accountId}/{month}")]
		public IEnumerable<IncomePlaning> Get(int accountId,int month)
		{
            return _incomePlaningService.ByAccountIdAndMonth(accountId, month);
		}

        [Route("")]
        [HttpPost]
        public IncomePlaning Post([FromBody] IncomePlaning item)
        {
            IResult<IncomePlaning> result = _incomePlaningService.Create(item);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{itemId}")]
        [HttpPost]
        public IncomePlaning Update(int itemId, [FromBody] IncomePlaning item)
        {
            IResult<IncomePlaning> result = _incomePlaningService.Update(item);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{itemId}")]
        public HttpResponseMessage Delete(int itemId)
        {
            IResult<bool> result = _incomePlaningService.Delete(itemId);
            if (result.IsSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        [Route("{accountId}")]
        public IEnumerable<int> GetPlaningMonths(int accountId)
        {
            return _incomePlaningService.ByAccountId(accountId);
        }

    }
}
