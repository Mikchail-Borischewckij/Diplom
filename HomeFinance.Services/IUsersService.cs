using HomeFinance.Contract;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services
{
    public interface IUsersService
    {
        UserInfo GetUserByToken(string token);
    }
}
