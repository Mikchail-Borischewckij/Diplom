using System.Data.Entity;
using System.Linq;
using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories.Impl
{
    internal class TokensRepository : RepositoryBase<Token>, ITokenCollections
    {
        public TokensRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<Token> All
        {
            get { return Query.Include(x=>x.User); }
        }
    }
}
