using HomeFinance.Data.Domain;

namespace HomeFinance.Data.Repositories
{
    public interface IUsersCollections : IRepository<User>
    {
        User GetUserByName(string email);
    }
}
