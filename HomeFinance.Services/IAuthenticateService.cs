using HomeFinance.Contract.Authorization;

namespace HomeFinance.Services
{
    public interface IAuthenticateService 
    {
		User Authenticate(User item);
        User Register(User item);
    }
}
