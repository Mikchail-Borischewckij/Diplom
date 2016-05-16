using System;
using HomeFinance.Contract.Authorization;
using HomeFinance.Core.Helpers;
using HomeFinance.Core.IoC;
using HomeFinance.Data;

namespace HomeFinance.Services.Impl
{
    public class AuthenticateService:IAuthenticateService
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;

        public AuthenticateService(LazyInject<IUnitOfWork> lazyUnitOfWork)
		{
			_lazyUnitOfWork = lazyUnitOfWork;
		}

        public User Authenticate(User item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.User current = unitOfWork.Users.GetUserByName(item.Name);
                    return CryptographyPasswordHelper.VerifyPassword(current.Password, item.Password)
                        ? EntitiesConverter.ToInternalContract(current)
                        : null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Register(User item)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    Data.Domain.User user = new Data.Domain.User();
                    user.CopyFromContract(item);
                    unitOfWork.Users.Create(user);
                    unitOfWork.SaveChanges();
                    return EntitiesConverter.ToInternalContract(user);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
