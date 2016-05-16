using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class CostsCategoryRepository : RepositoryBase<CostsCategory>, ICostsCategoryCollections
    {
        public CostsCategoryRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<CostsCategory> ByUserId(int userId)
        {
            return Query.Where(x => x.UserId == userId).AsEnumerable();
        }
    }
}
