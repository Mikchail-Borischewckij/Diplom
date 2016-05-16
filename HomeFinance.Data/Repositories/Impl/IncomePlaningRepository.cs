using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class IncomePlaningRepository : PlaningBaseRepository<IncomePlaning>, IIncomePlaningCollections
    {
        public IncomePlaningRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<IncomePlaning> GetAllByCategoryIdAndMonth(int categoryId, int month)
        {
            return Query.Include(x => x.IncomeCategory).Where(x => x.IncomeCategory.Id == categoryId && x.Date.Month == month).ToList();
        }
    }
}
