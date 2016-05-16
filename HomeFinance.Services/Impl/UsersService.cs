using System;
using System.Linq;
using HomeFinance.Contract.Data;
using HomeFinance.Core.IoC;
using HomeFinance.Data;
using HomeFinance.Data.Domain;

namespace HomeFinance.Services.Impl
{
    public class UsersService : IUsersService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public UsersService(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public UserInfo GetUserByToken(string token)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Token currentToken =
                    unitOfWork.Tokens.FirstOrDefault(
                        x => Guid.Parse(x.AuthToken)==Guid.Parse(token));
                User user = unitOfWork.Users.ById(currentToken.UserId);
                return EntitiesConverter.ToContract(user);
            }
        }
    }
}
