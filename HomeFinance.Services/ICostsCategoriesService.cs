using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ICostsCategoriesService : ICrudService<CostsCategory>
    {
        IEnumerable<CostsCategory> AllByUserId(int userId);
    }
}
