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
    [RoutePrefix("api/costsCategories")]
    public class CostsCategoriesController : ApiController
    {
        private readonly ICostsCategoriesService _costsCategoriesService;

        public CostsCategoriesController(ICostsCategoriesService costsCategoriesService)
        {
            _costsCategoriesService = costsCategoriesService;
        }
        
        [HttpGet]
        [Route("all/{userId}")]
        public IEnumerable<CostsCategory> GetAllByUser(int userId)
        {
            return _costsCategoriesService.AllByUserId(userId);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public CostsCategory Read(int categoryId)
        {
            return _costsCategoriesService.Read(categoryId);
        }

        [HttpPost]
        [Route("")]
        public CostsCategory Post([FromBody] CostsCategory category)
        {
            IResult<CostsCategory> result = _costsCategoriesService.Create(category);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("{categoryId}")]
        public CostsCategory Post(int categoryId, [FromBody] CostsCategory category)
        {
            IResult<CostsCategory> result = _costsCategoriesService.Update(category);
            if (result.IsSuccess)
            {
                return result.Model;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        [Route("{categoryId}")]
        public HttpResponseMessage Delete(int categoryId)
        {
            IResult<bool> result = _costsCategoriesService.Delete(categoryId);
            if (result.IsSuccess)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
        
    }
}
