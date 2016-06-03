using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ICostsPlaningService : ICrudService<CostsPlaning>
    {
        IEnumerable<CostsPlaning> ByAccountIdAndMonth(int accountId, int month);
        IEnumerable<int> ByMonthsByAccountId(int accountId);
    }
}
