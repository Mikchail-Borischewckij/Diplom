using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class CurrencyService : ICurrencyService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;
        private readonly ICurrencyProvider _currencyProvider;

        public CurrencyService(LazyInject<IUnitOfWork> lazyUnitOfWork,ICurrencyProvider currencyProvider)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
            _currencyProvider = currencyProvider;
        }

        public IResult<Currency> Create(Currency item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Currency currency = new Data.Domain.Currency();
                currency.CopyFromContract(item);
                unitOfWork.Currencys.Create(currency);
                unitOfWork.SaveChanges();
                return new Result<Currency>(true, EntitiesConverter.ToContract(currency));
            }
        }

        public Currency Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Currency currency = unitOfWork.Currencys.ById(itemId);
                return EntitiesConverter.ToContract(currency);
            }
        }

        public IResult<Currency> Update(Currency item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Currency currency = unitOfWork.Currencys.ById(item.Id);
                currency.CopyFromContract(item);
                unitOfWork.Currencys.Update(currency);
                unitOfWork.SaveChanges();
                return new Result<Currency>(true, EntitiesConverter.ToContract(currency));
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Currency currency = unitOfWork.Currencys.ById(itemId);
                unitOfWork.Currencys.Delete(currency);
                unitOfWork.SaveChanges();
                return new Result<bool>(true);
            }
        }

        public IEnumerable<Currency> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.Currencys.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<Currency> GetCurrentCurrenciesValues()
        {
            return _currencyProvider.GetCurrenciesValues(DateTime.Now);
        }
    }
}
