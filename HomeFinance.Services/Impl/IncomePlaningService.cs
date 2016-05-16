using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class IncomePlaningService : IIncomePlaningService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public IncomePlaningService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<IncomePlaning> Create(IncomePlaning item)
        {
            try
            {
                if (CheckExistingPlanning(item))
                {
                    return new Result<IncomePlaning>(false);
                }

                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.IncomePlaning incomePlaning = new Data.Domain.IncomePlaning();
                    incomePlaning.CopyFromContract(item);
                    unitOfWork.IncomesPlaning.Create(incomePlaning);
                    unitOfWork.SaveChanges();
                    return new Result<IncomePlaning>(true, EntitiesConverter.ToContract(incomePlaning));
                }
            }
            catch (Exception ex)
            {
                return new Result<IncomePlaning>(false);
            }
        }

        public IncomePlaning Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return EntitiesConverter.ToContract(unitOfWork.IncomesPlaning.ById(itemId));
            }
        }

        public IResult<IncomePlaning> Update(IncomePlaning item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.IncomePlaning incomePlaning = unitOfWork.IncomesPlaning.ById(item.Id);
                incomePlaning.CopyFromContract(item);
                unitOfWork.IncomesPlaning.Update(incomePlaning);
                unitOfWork.SaveChanges();
                return new Result<IncomePlaning>(true, EntitiesConverter.ToContract(incomePlaning));
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.IncomePlaning incomePlaning = unitOfWork.IncomesPlaning.ById(itemId);
                unitOfWork.IncomesPlaning.Delete(incomePlaning);
                unitOfWork.SaveChanges();
                return new Result<bool>(true, string.Empty);
            }
        }

        public IEnumerable<IncomePlaning> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.IncomesPlaning.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<IncomePlaning> ByAccountIdAndMonth(int accountId, int month)
	    {
			using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
			{
                return unitOfWork.IncomesPlaning.GetAllByAccountIdAndMonth(accountId, month).Select(EntitiesConverter.ToContract);
			}
	    }

        public IEnumerable<int> ByAccountId(int accountId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.IncomesPlaning.GetMoths(accountId);
            }
        }

        private bool CheckExistingPlanning(IncomePlaning item)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.IncomesPlaning.GetAllByCategoryIdAndMonth(item.CategoryId,item.Date.Month).Any();
            }
        }
    }
}
