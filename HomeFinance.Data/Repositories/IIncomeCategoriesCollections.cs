using System.Collections.Generic;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface IIncomeCategoriesCollections : IRepository<IncomeCategory>
    {
        IEnumerable<IncomeCategory> ByUserId(int userId);
    }
}
