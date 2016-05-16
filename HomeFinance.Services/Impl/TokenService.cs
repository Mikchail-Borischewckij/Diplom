using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Authorization;
using HomeFinance.Contract.Data;
using HomeFinance.Core;
using HomeFinance.Core.IoC;
using IUnitOfWork = HomeFinance.Data.IUnitOfWork;
using User = HomeFinance.Data.Domain.User;

namespace HomeFinance.Services.Impl
{
    public class TokenServices : ITokenServices
    {
        private readonly LazyInject<IUnitOfWork> _lazyUnitOfWork;
		
        public TokenServices(LazyInject<IUnitOfWork> lazyUnitOfWork)
        {
            _lazyUnitOfWork = lazyUnitOfWork;
        }

        public IResult<Token> GenerateToken(int userId)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    User user = unitOfWork.Users.FirstOrDefault(x => x.Id == userId);
                    DeleteInvalidTokens(unitOfWork, userId);
                    Data.Domain.Token token = new Data.Domain.Token()
                    {
                        AuthToken = Guid.NewGuid().ToString(),
                        IssuedOn = DateTime.Now,
                        ExpiresOn = DateTime.Now.AddSeconds(AppSetting.AuthTokenExpiry),
                        User = user,
                        UserId = user.Id
                    };
                    unitOfWork.Tokens.Create(token);
                    unitOfWork.SaveChanges();
                    return new Result<Token>(true, EntitiesConverter.ToInternalContract(token));
                }
            }
            catch (Exception ex)
            {
                return new Result<Token>(false);
            }
        }

        private void DeleteInvalidTokens(IUnitOfWork unitOfWork,int userId)
        {
            IEnumerable<Data.Domain.Token> invalidTokens = unitOfWork.Tokens.Where(x => x.UserId == userId);
            foreach (Data.Domain.Token token in invalidTokens)
            {
                unitOfWork.Tokens.Delete(token);
            }
        }

        public IResult<bool> ValidateToken(string tokenId)
        {
            using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
            {
                Data.Domain.Token token =
                    unitOfWork.Tokens.FirstOrDefault(t => Guid.Parse(t.AuthToken) == Guid.Parse(tokenId));
                if (token != null && DateTime.Now.CompareTo(token.ExpiresOn) < 0)
                {
                    return new Result<bool>(true);
                }
            }
            return new Result<bool>(false);
        }

        public IResult<bool> DeleteByUserId(int userId)
        {
            try
            {
                using (IUnitOfWork unitOfWork = _lazyUnitOfWork.Value)
                {
                    DeleteInvalidTokens(unitOfWork, userId);
                    return new Result<bool>(true);
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }
    }
}
