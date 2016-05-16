using System.Collections.Generic;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface IAccountsService : ICrudService<Account>
    {
        IEnumerable<Account> AllByUserId(int userId);
        Account ByUserId(int userId);
    }
}
