using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class CostsRepository : RepositoryBase<Cost>, ICostsCollections
    {
        public CostsRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Cost> GetAllByAccountId(int accountId)
        {
            return Query.Where(x => x.AccountId == accountId).AsEnumerable();
        }
    }
}
