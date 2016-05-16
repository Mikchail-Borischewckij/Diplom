using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface IIncomeCollections : IRepository<Income>
    {
        IEnumerable<Income> GetAllByAccountId(int accountId);
    }
}
