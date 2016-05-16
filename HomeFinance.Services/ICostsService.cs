using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ICostsService : ICrudService<Cost>
    {
        IEnumerable<Cost> GetAllByIAccountd(int accountId);
    }
}
