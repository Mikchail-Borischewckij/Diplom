using System.Data.Entity;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class CurrencyRepository : RepositoryBase<Currency>, ICurrencyCollections
    {
        public CurrencyRepository(DbContext context)
            : base(context)
        {
        }
    }
}
