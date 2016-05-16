using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface IIncomePlaningCollections : IRepository<IncomePlaning>
    {
		IEnumerable<IncomePlaning> GetAllByAccountIdAndMonth(int accountId,int month);
        IEnumerable<IncomePlaning> GetAllByCategoryIdAndMonth(int categoryId, int month);
        IEnumerable<int> GetMoths(int accountId);
    }
}
