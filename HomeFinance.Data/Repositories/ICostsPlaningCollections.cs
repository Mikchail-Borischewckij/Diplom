using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface ICostsPlaningCollections : IRepository<CostsPlaning>
    {
        IEnumerable<CostsPlaning> GetAllByAccountIdAndMonth(int accountId, int month);
        IEnumerable<int> GetMoths(int accountId);
        IEnumerable<CostsPlaning> GetAllByCategoryIdAndMonth(int categoryId, int month);
    }
}
