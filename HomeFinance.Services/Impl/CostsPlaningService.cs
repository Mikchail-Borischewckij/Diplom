using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class CostsPlaningService : ICostsPlaningService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public CostsPlaningService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<CostsPlaning> Create(CostsPlaning item)
        {
            try
            {
                if (CheckExistingPlanning(item))
                {
                    return new Result<CostsPlaning>(false);
                }

                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.CostsPlaning costsPlaning = new Data.Domain.CostsPlaning();
                    costsPlaning.CopyFromContract(item);
                    unitOfWork.CostsPlaning.Create(costsPlaning);
                    unitOfWork.SaveChanges();
                    return new Result<CostsPlaning>(true, EntitiesConverter.ToContract(costsPlaning));
                }
            }
            catch (Exception ex)
            {
                return new Result<CostsPlaning>(false);
            }
        }

        public CostsPlaning Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return EntitiesConverter.ToContract(unitOfWork.CostsPlaning.ById(itemId));
            }
        }

        public IResult<CostsPlaning> Update(CostsPlaning item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.CostsPlaning costsPlaning = unitOfWork.CostsPlaning.ById(item.Id);
                costsPlaning.CopyFromContract(item);
                unitOfWork.CostsPlaning.Update(costsPlaning);
                unitOfWork.SaveChanges();
                return new Result<CostsPlaning>(true, EntitiesConverter.ToContract(costsPlaning));
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.CostsPlaning costsPlaning = unitOfWork.CostsPlaning.ById(itemId);
                unitOfWork.CostsPlaning.Delete(costsPlaning);
                unitOfWork.SaveChanges();
                return new Result<bool>(true, string.Empty);
            }
        }

        public IEnumerable<CostsPlaning> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsPlaning.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<CostsPlaning> ByAccountIdAndMonth(int accountId, int month)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsPlaning.GetAllByAccountIdAndMonth(accountId, month).Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<int> ByMonthsByAccountId(int accountId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsPlaning.GetMoths(accountId);
            }
        }

        private bool CheckExistingPlanning(CostsPlaning item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsPlaning.GetAllByCategoryIdAndMonth(item.CategoryId, item.Date.Month).Any();
            }
        }
    }
}
