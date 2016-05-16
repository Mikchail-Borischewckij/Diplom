using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class PlaningBaseRepository<T> : RepositoryBase<T> where T : Planing
    {
        public PlaningBaseRepository(DbContext context) : base(context)
        {
        }
        
        public IEnumerable<T> GetAllByAccountIdAndMonth(int accountId, int month)
        {
            return Query.Include(x => x.Account).Where(x => x.Account.Id == accountId && x.Date.Month == month).ToList();
        }

        public IEnumerable<int> GetMoths(int accountId)
        {
            return Query.Include(x => x.Account)
                 .Where(x => x.Date.Year == DateTime.Now.Year)
                 .Select(x => x.Date.Month)
                 .Distinct()
                 .ToList();
        }
    }
}
