using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;
using Account = HomeFinance.Data.Domain.Account;

namespace HomeFinance.Services.Impl
{
    public class IncomeService : IIncomeService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public IncomeService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<Income> Create(Income item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.Income income = new Data.Domain.Income();
                    income.CopyFromContract(item);
                    income.CreatedDate = DateTime.Now;
                    Account account = unitOfWork.Accounts.ById(item.AccountId);
                    income.IncomeCategory = unitOfWork.IncomeCategories.ById(item.CategoryId);
                    UpdateAccount(item, account, unitOfWork);
                    unitOfWork.Incomes.Create(income);
                    unitOfWork.SaveChanges();
                    return new Result<Income>(true, EntitiesConverter.ToContract(income));
                }
            }
            catch (Exception ex)
            {
                return new Result<Income>(false);
            }
        }

        public Income Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Income income = unitOfWork.Incomes.ById(itemId);
                return EntitiesConverter.ToContract(income);
            }
        }

        public IResult<Income> Update(Income item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.Income income = unitOfWork.Incomes.ById(item.Id);
                    income.CopyFromContract(item);
                    income.CreatedDate = DateTime.Now;
                    Account account = unitOfWork.Accounts.ById(item.AccountId);
                    income.IncomeCategory = unitOfWork.IncomeCategories.ById(item.CategoryId);
                    UpdateAccount(item, account, unitOfWork);
                    unitOfWork.Incomes.Update(income);
                    unitOfWork.SaveChanges();
                    return new Result<Income>(true, EntitiesConverter.ToContract(income));
                }
            }
            catch (Exception ex)
            {
                return new Result<Income>(false);
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Income income = unitOfWork.Incomes.ById(itemId);
                unitOfWork.Incomes.Delete(income);
                unitOfWork.SaveChanges();
                return new Result<bool>(true, string.Empty);
            }
        }

        public IEnumerable<Income> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Income> incomes = unitOfWork.Incomes;
                return incomes.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<Income> GetAllByIAccountd(int accountId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Income> incomes = unitOfWork.Incomes.GetAllByAccountId(accountId);
                return incomes.Select(EntitiesConverter.ToContract);
            }
        }

        private void UpdateAccount(Income income, Account account, IUnitOfWork unitOfWork)
        {
            if (income.TransactionType == TransactionType.Single)
            {
                account.AmountMoney += income.Amount;
                unitOfWork.Accounts.Update(account);
            }
        }
    }
}
