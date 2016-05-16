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
    public class CostsService : ICostsService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public CostsService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<Cost> Create(Cost item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.Cost cost = new Data.Domain.Cost();
                    cost.CopyFromContract(item);
                    cost.CreatedDate = DateTime.Now;
                    cost.Account = unitOfWork.Accounts.ById(item.AccountId);
                    cost.CostCategory = unitOfWork.CostsCategories.ById(item.CategoryId);
                    UpdateAccount(item, cost.Account, unitOfWork);
                    unitOfWork.Costses.Create(cost);
                    unitOfWork.SaveChanges();
                    return new Result<Cost>(true, EntitiesConverter.ToContract(cost));
                }
            }
            catch (Exception ex)
            {
                return new Result<Cost>(false, null, ex);
            }
        }

        public Cost Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Cost cost = unitOfWork.Costses.ById(itemId);
                return EntitiesConverter.ToContract(cost);
            }
        }

        public IResult<Cost> Update(Cost item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.Cost cost = unitOfWork.Costses.ById(item.Id);
                    cost.CopyFromContract(item);
                    cost.CreatedDate = DateTime.Now;
                    cost.Account = unitOfWork.Accounts.ById(item.AccountId);
                    cost.CostCategory = unitOfWork.CostsCategories.ById(item.CategoryId);
                    UpdateAccount(item, cost.Account, unitOfWork);
                    unitOfWork.Costses.Update(cost);
                    unitOfWork.SaveChanges();
                    return new Result<Cost>(true, EntitiesConverter.ToContract(cost));
                }
            }
            catch (Exception ex)
            {
                return new Result<Cost>(false,null, ex);
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Cost cost = unitOfWork.Costses.ById(itemId);
                unitOfWork.Costses.Delete(cost);
                unitOfWork.SaveChanges();
                return new Result<bool>(true, string.Empty);
            }
        }

        public IEnumerable<Cost> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Cost> consumptions  = unitOfWork.Costses;
                return consumptions.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<Cost> GetAllByIAccountd(int accountId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                IEnumerable<Data.Domain.Cost> costs = unitOfWork.Costses.GetAllByAccountId(accountId);
                return costs.Select(EntitiesConverter.ToContract);
            }
        }


        private void UpdateAccount(Cost cost, Account account, IUnitOfWork unitOfWork)
        {
            if (account == null)
            {
                throw new ArgumentException();
            }

            if (cost.TransactionType == TransactionType.Single)
            {
                account.AmountMoney -= cost.Amount;
                if (account.AmountMoney < 0)
                {
                    throw new ArgumentException();
                }
                unitOfWork.Accounts.Update(account);
            }
        }
    }
}
