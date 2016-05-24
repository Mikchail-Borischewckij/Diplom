using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
