using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface IIncomePlaningService : ICrudService<IncomePlaning>
    {
	    IEnumerable<IncomePlaning> ByAccountIdAndMonth(int accountId,int month);
        IEnumerable<int> ByAccountId(int accountId);
    }
}
