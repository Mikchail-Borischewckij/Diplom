using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface ICostsCollections : IRepository<Cost>
    {
        IEnumerable<Cost> GetAllByAccountId(int accountId);
    }
}
