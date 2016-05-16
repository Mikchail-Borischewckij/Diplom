using System.ServiceModel;
using HomeFinance.Contract;

namespace HomeFinance.Host
{
    [ServiceContract]
    public interface IAddinNotificatorService
    {
        [OperationContract]
        IResult<bool> UpdateAccount();
    }
}
