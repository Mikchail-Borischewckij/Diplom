using System;
using System.Collections.Generic;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface ICurrencyProvider
    {
        IEnumerable<Currency> GetCurrenciesValues(DateTime dateTime);
    }
}
