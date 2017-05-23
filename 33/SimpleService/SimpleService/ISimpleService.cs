using System.ServiceModel;

namespace SimpleService
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract(IsOneWay = false)] // IsOneWay is false by default
        string RequestReplyOperation();

        [OperationContract]
        string RequestReplyOperation_ThrowsException();

        [OperationContract(IsOneWay = true)]
        // OneWay operations must not declare output parameter.
        void OneWayOperation();

        [OperationContract(IsOneWay = true)]
        void OneWayOperation_ThrowsException();
    }
}
