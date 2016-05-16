using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ICurrencyService : ICrudService<Currency>
    {
        IEnumerable<Currency> GetCurrentCurrenciesValues();
    }

}
