using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class IncomeCategoriesRepository : RepositoryBase<IncomeCategory>, IIncomeCategoriesCollections
    {
        public IncomeCategoriesRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<IncomeCategory> ByUserId(int userId)
        {
            return Query.Where(x => x.UserId == userId).AsEnumerable();
        }
    }
}
