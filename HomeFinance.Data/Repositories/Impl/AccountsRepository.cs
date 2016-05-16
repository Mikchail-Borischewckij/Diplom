using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class AccountsRepository : RepositoryBase<Account>, IAccountsCollections
    {
        public AccountsRepository(DbContext context)
            : base(context)
        {
        }

        public override Account ById(int id)
        {
            return All().FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Account> All()
        {
            return Query.Include(x => x.Currency)
                .Include(x => x.Incomes)
                .Include(x=>x.Сonsumptions);
        }

        public IEnumerable<Account> ByUserId(int userId)
        {
            return All().Where(x=>x.UserId ==userId);
        }
    }
}
