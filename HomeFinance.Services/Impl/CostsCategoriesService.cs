using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class CostsCategoriesService : ICostsCategoriesService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public CostsCategoriesService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<CostsCategory> Create(CostsCategory item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.CostsCategory category = new Data.Domain.CostsCategory();
                    category.CopyFromContract(item);
                    category.User = unitOfWork.Users.ById(item.UserId);
                    unitOfWork.CostsCategories.Create(category);
                    unitOfWork.SaveChanges();
                    return new Result<CostsCategory>(true, EntitiesConverter.ToContract(category));
                }
            }
            catch (Exception ex)
            {
                return new Result<CostsCategory>(false);
            }
        }

        public CostsCategory Read(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.CostsCategory category = unitOfWork.CostsCategories.ById(itemId);
                return EntitiesConverter.ToContract(category);
            }
        }

        public IResult<CostsCategory> Update(CostsCategory item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.CostsCategory category = unitOfWork.CostsCategories.ById(item.Id);
                    category.CopyFromContract(item);
                    category.User = unitOfWork.Users.ById(item.UserId);
                    unitOfWork.CostsCategories.Update(category);
                    unitOfWork.SaveChanges();
                    return new Result<CostsCategory>(true, EntitiesConverter.ToContract(category));
                }
            }
            catch (Exception ex)
            {
                return new Result<CostsCategory>(false);
            }
        }

        public IResult<bool> Delete(int itemId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.CostsCategory category = unitOfWork.CostsCategories.ById(itemId);
                unitOfWork.CostsCategories.Delete(category);
                unitOfWork.SaveChanges();
                return new Result<bool>(true);
            }
        }

        public IEnumerable<CostsCategory> ReadAll()
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsCategories.Select(EntitiesConverter.ToContract);
            }
        }

        public IEnumerable<CostsCategory> AllByUserId(int userId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                return unitOfWork.CostsCategories.ByUserId(userId).Select(EntitiesConverter.ToContract);
            }
        }
    }
}
