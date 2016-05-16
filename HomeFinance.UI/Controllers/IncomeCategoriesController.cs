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
    [RoutePrefix("api/incomeCategories")]
    public class IncomeCategoriesController : ApiController
    {
        private readonly IIncomeCategoriesService _incomeCategoriesService;

        public IncomeCategoriesController(IIncomeCategoriesService incomeCategoriesService)
        {
            _incomeCategoriesService = incomeCategoriesService;
		}

        [HttpGet]
        [Route("{categoryId}")]
        public IncomeCategory Read(int categoryId)
        {
            return _incomeCategoriesService.Read(categoryId);
        }

        [HttpGet]
        [Route("all/{userId}")]
        public IEnumerable<IncomeCategory> GetAllByUser(int userId)
        {
            return _incomeCategoriesService.AllByUserId(userId);
        }

        [HttpPost]
        [Route("")]
        public IncomeCategory Post([FromBody] IncomeCategory category)
        {
            IResult<IncomeCategory> result = _incomeCategoriesService.Create(category);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("{categoryId}")]
        public IncomeCategory Post(int categoryId, [FromBody] IncomeCategory category)
        {
            IResult<IncomeCategory> result = _incomeCategoriesService.Update(category);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{categoryId}")]
        public HttpResponseMessage Delete(int categoryId)
        {
            IResult<bool> result = _incomeCategoriesService.Delete(categoryId);
            if (result.IsSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}
