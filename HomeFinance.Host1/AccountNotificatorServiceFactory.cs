using HomeFinance.Data;
using HomeFinance.Data.Impl;
using HomeFinance.Services;
using HomeFinance.Services.Impl;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace HomeFinance.Host1
{
	public class AccountNotificatorServiceFactory : UnityServiceHostFactory
	{
		protected override void ConfigureContainer(IUnityContainer container)
		{
		    container.RegisterType<IUnitOfWork, UnitOfWork>()
		        .RegisterType<IAccountsService, AccountsService>()
		        .RegisterType<IIncomeService, IncomeService>()
		        .RegisterType<ICostsService, CostsService>()
		        .RegisterType<IAccountNotificatorService, AccountNotificatorService>();

		}
	}
}