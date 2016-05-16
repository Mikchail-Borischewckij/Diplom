using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface IAccountsCollections : IRepository<Account>
    {
        IEnumerable<Account> All();
        IEnumerable<Account> ByUserId(int userId);
    }
}
