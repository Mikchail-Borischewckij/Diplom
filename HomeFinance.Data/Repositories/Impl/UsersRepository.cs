using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class UsersRepository : RepositoryBase<User>, IUsersCollections
    {
        public UsersRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<User> All
        {
            get { return Query.Include(x => x.IncomeCategories); }
        }

        public User GetUserByName(string email)
	    {
			return All.FirstOrDefault(x => x.Name.Equals(email, StringComparison.InvariantCultureIgnoreCase));
	    }
    }
}
