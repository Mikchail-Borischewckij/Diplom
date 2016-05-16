using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface ICostsCategoryCollections : IRepository<CostsCategory>
    {
        IEnumerable<CostsCategory> ByUserId(int userId);
    }
}
