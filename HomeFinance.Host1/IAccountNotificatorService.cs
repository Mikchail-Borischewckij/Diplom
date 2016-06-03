using System.ServiceModel;

namespace HomeFinance.Host1
{
    [ServiceContract]
	public interface IAccountNotificatorService
	{
		[OperationContract]
		void StartUpdateAccounts();

		[OperationContract]
		void StopUpdateAccounts();
	}
	
}
