using System.ServiceModel;

namespace SimpleService
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract(IsOneWay = false)]
        string RequestReplyOperation();

        [OperationContract]
        string RequestReplyOperation_ThrowsException();
    }
}
