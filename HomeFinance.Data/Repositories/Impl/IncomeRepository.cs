using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class IncomeRepository : RepositoryBase<Income>, IIncomeCollections
    {
        public IncomeRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Income> GetAllByAccountId(int accountId)
        {
            return Query.Where(x => x.AccountId == accountId).AsEnumerable();
        }
    }
}
