using HomeFinance.Data;
using HomeFinance.Data.Impl;
using HomeFinance.Services.Impl;
using Microsoft.Practices.Unity;

namespace HomeFinance.Services
{
	public class Bootstrapper
	{
		public static void InitializeContainer(IUnityContainer container)
		{
            container.RegisterType<ITokenServices, TokenServices>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAuthenticateService, AuthenticateService>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IIncomeService, IncomeService>();
            container.RegisterType<ICostsService, CostsService>();
            container.RegisterType<IAccountsService, AccountsService>();
            container.RegisterType<ICurrencyService, CurrencyService>();
            container.RegisterType<IIncomeCategoriesService, IncomeCategoriesService>();
            container.RegisterType<ICostsCategoriesService, CostsCategoriesService>();
			container.RegisterType<IIncomePlaningService, IncomePlaningService>();
			container.RegisterType<ICostsPlaningService, CostsPlaningService>();
            container.RegisterType<ICurrencyProvider, CurrencyProvider>();
		}
	}
}
