using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface IIncomeService : ICrudService<Income>
    {
        IEnumerable<Income> GetAllByIAccountd(int accountId);
    }
}
