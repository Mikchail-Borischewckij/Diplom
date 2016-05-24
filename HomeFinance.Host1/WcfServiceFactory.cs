using HomeFinance.Data;
using HomeFinance.Data.Impl;
using HomeFinance.Services;
using HomeFinance.Services.Impl;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace HomeFinance.Host1
{
	public class WcfServiceFactory : UnityServiceHostFactory
	{
		protected override void ConfigureContainer(IUnityContainer container)
		{
			// register all your components with the container here
			container
			   .RegisterType<IAccountNotificatorService, AccountNotificatorService>()
				  .RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager())
			   .RegisterType<IAccountsService, AccountsService>()
			.RegisterType<IIncomeService, IncomeService>()
			.RegisterType<ICostsService, CostsService>();
		}
	}
}