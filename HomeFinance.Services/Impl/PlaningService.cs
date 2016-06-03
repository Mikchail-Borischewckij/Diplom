using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Core.IoC;
using HomeFinance.Data;
using HomeFinance.Data.Domain;

namespace HomeFinance.Services.Impl
{
    internal class PlaningService : IPlaningService
    {
         private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

         public PlaningService(LazyInject<IUnitOfWork> lazyUnitOfWork)
		{
			_lazyUnitOfWork = lazyUnitOfWork;
		}

        public double GetAverageBalanceByAccountd(int accountId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Account account = unitOfWork.Accounts.ById(accountId);
                IEnumerable<int> incomes = account.Incomes.Select(x => x.CreatedDate.Month);
                IEnumerable<int> costs = account.Сonsumptions.Select(x => x.CreatedDate.Month);
                IEnumerable<int> months = incomes.Concat(costs).Distinct();

                var result = new List<double>();
                foreach (int month in months)
                {
                    double incomesSum = account.Incomes.Where(x => x.CreatedDate.Month == month).Sum(x => x.Amount);
                    double costsSum = account.Сonsumptions.Where(x => x.CreatedDate.Month == month).Sum(x => x.Amount);
                    result.Add(incomesSum - costsSum);
                }
                return result.Sum() / months.Count();
            }
        }
    }
}
