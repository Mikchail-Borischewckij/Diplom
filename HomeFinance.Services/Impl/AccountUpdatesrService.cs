using System;
using System.Collections.Generic;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;
using Account = HomeFinance.Data.Domain.Account;
using Cost = HomeFinance.Data.Domain.Cost;
using Income = HomeFinance.Data.Domain.Income;

namespace HomeFinance.Services.Impl
{
    internal class AccountUpdatesrService :IAccountUpdatesrService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public AccountUpdatesrService(LazyInject<IUnitOfWork> lazyUnitOfWork)
		{
			_lazyUnitOfWork = lazyUnitOfWork;
		}

        public IResult<bool> UpdateAccounts()
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    IEnumerable<Account> accounts = unitOfWork.Accounts.All();
                    foreach (Account account in accounts)
                    {
                        IEnumerable<Income> incomes = unitOfWork.Incomes.GetAllByAccountId(account.Id);
                        UpdateIncomes(unitOfWork, incomes, account);
                        IEnumerable<Cost> costs = unitOfWork.Costses.GetAllByAccountId(account.Id);
                        UpdateCosts(unitOfWork, costs, account);
                    }
                    unitOfWork.SaveChanges();
                    return new Result<bool>(true);
                }
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        private void UpdateIncomes(IUnitOfWork unitOfWork,IEnumerable<Income> incomes,Account account)
        {
            foreach (Income income in incomes)
            {
                TransactionType type;
                if (!income.UpdatedDate.HasValue || income.UpdatedDate.Value.Date != DateTime.Now.Date || !Enum.TryParse(income.TransactionType.ToString(), out type))
                {
                    continue;
                }

                if (type == TransactionType.Mountly)
                {
                    account.AmountMoney += income.Amount;
                    income.UpdatedDate = DateTime.Now.AddMonths(1);
                    unitOfWork.Incomes.Update(income);
                }
            }
        }

        private void UpdateCosts(IUnitOfWork unitOfWork, IEnumerable<Cost> costs, Account account)
        {
            foreach (Cost cost in costs)
            {
                TransactionType type;
                if (!cost.UpdatedDate.HasValue || cost.UpdatedDate.Value.Date != DateTime.Now.Date ||  !Enum.TryParse(cost.TransactionType.ToString(), out type))
                {
                    continue;
                }

                if (type == TransactionType.Mountly)
                {
                    account.AmountMoney += cost.Amount;
                    cost.UpdatedDate = DateTime.Now.AddMonths(1);
                    unitOfWork.Costses.Update(cost);
                }
            }
        }
    }
}
