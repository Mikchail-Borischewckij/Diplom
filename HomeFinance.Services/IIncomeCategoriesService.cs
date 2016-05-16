using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface IIncomeCategoriesService : ICrudService<IncomeCategory>
    {
        IEnumerable<IncomeCategory> AllByUserId(int userId);
    }
}
