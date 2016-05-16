using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class IncomeCategoriesService:IIncomeCategoriesService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public IncomeCategoriesService(LazyInject<IUnitOfWork> lazyUnitOfWork)
		{
			_lazyUnitOfWork = lazyUnitOfWork;
		}

        public IResult<IncomeCategory> Create(IncomeCategory item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.IncomeCategory category = new Data.Domain.IncomeCategory();
                    category.CopyFromContract(item);
                    category.User = unitOfWork.Users.ById(item.UserId);
                    unitOfWork.IncomeCategories.Create(category);
                    unitOfWork.SaveChanges();
                    return new Result<IncomeCategory>(true, EntitiesConverter.ToContract(category));
                }
            }
            catch (Exception ex)
            {
                return new Result<IncomeCategory>(false);
            }
        }

        public IncomeCategory Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.IncomeCategory category = unitOfWork.IncomeCategories.ById(itemId);
                return EntitiesConverter.ToContract(category);
            }
        }

        public IResult<IncomeCategory> Update(IncomeCategory item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.IncomeCategory category = unitOfWork.IncomeCategories.ById(item.Id);
                    category.CopyFromContract(item);
                    category.User = unitOfWork.Users.ById(item.UserId);
                    unitOfWork.IncomeCategories.Update(category);
                    unitOfWork.SaveChanges();
                    return new Result<IncomeCategory>(true, EntitiesConverter.ToContract(category));
                }
            }
            catch (Exception ex)
            {
                return new Result<IncomeCategory>(false);
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.IncomeCategory category = unitOfWork.IncomeCategories.ById(itemId);
                unitOfWork.IncomeCategories.Delete(category);
                unitOfWork.SaveChanges();
                return new Result<bool>(true);
            }
        }

        public IEnumerable<IncomeCategory> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
               return unitOfWork.IncomeCategories.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<IncomeCategory> AllByUserId(int userId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.IncomeCategories.ByUserId(userId).Select(EntitiesConverter.ToContract);
            }
        }
    }
}
