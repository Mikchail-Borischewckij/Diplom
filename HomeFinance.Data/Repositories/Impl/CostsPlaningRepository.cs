using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class CostsPlaningRepository : PlaningBaseRepository<CostsPlaning>, ICostsPlaningCollections
    {
        public CostsPlaningRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<CostsPlaning> GetAllByCategoryIdAndMonth(int categoryId, int month)
        {
            return Query.Include(x => x.CostsCategory).Where(x => x.CostsCategory.Id == categoryId && x.Date.Month == month).ToList();
        }
    }
}
