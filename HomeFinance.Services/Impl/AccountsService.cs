using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class AccountsService:IAccountsService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public AccountsService(LazyInject<IUnitOfWork> lazyUnitOfWork)
		{
			_lazyUnitOfWork = lazyUnitOfWork;
		}

        public IResult<Account> Create(Account item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.Account account = new Data.Domain.Account();
                    account.CopyFromContract(item);
                    account.CreatedDate = DateTime.Now;
                    account.Currency = unitOfWork.Currencys.ById(item.CurrencyId);
                    account.User = unitOfWork.Users.ById(item.UserId);
                    unitOfWork.Accounts.Create(account);
                    unitOfWork.SaveChanges();
                    return new Result<Account>(true, EntitiesConverter.ToContract(account));
                }
            }
            catch (Exception ex)
            {
                return new Result<Account>(false);
            }
          }

        public Account Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Account account = unitOfWork.Accounts.ById(itemId);
                return EntitiesConverter.ToContract(account);
            }
        }

        public IResult<Account> Update(Account item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Account account = unitOfWork.Accounts.ById(item.Id);
                account.CopyFromContract(item);
                account.Currency = unitOfWork.Currencys.ById(item.CurrencyId);
                unitOfWork.Accounts.Update(account);
                unitOfWork.SaveChanges();
                return new Result<Account>(true, EntitiesConverter.ToContract(account));
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Account account = unitOfWork.Accounts.ById(itemId);
                unitOfWork.Accounts.Delete(account);
                unitOfWork.SaveChanges();
                return new Result<bool>(true,string.Empty);
            }
        }

        public IEnumerable<Account> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Account> accounts = unitOfWork.Accounts.All();
                return accounts.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<Account> AllByUserId(int userId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Account> accounts = unitOfWork.Accounts.ByUserId(userId);
                return accounts.Select(EntitiesConverter.ToContract);
            }
        }

        public Account ByUserId(int userId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Account account = unitOfWork.Accounts.ByUserId(userId).FirstOrDefault();
                return EntitiesConverter.ToContract(account);
            }
        }
    }
}
