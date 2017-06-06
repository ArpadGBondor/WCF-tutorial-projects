using System.ServiceModel;

namespace SimpleService
{
    [ServiceContract]
    public interface ISimpleService
    {
        // Message Exchange Patterns:
        //  - IsOneWay parameter of OperationContract attribute specifies the 
        //    Message Exchange Pattern. The default value for IsOneWay parameter 
        //    is false. This means that, if we don't specify this parameter, 
        //    then the Message Exchange Pattern is Request/Reply. 

        // Request-Reply Message Exchange Pattern:
        //  - This is the default Message Exchange Pattern
        //  - The client sends a message to the WCF service and then waits for
        //    the reply message, even if the service operation's return type is 
        //    void.
        //  - The client waits for the service call to complete even if the 
        //    operation return type is void.
        //  - All WCF bindings except the MSMQ-based bindings support the 
        //    Request-Reply Message Exchange Pattern.
        //  - In a Request-Reply message pattern faulst and exceptions get 
        //    reported to the client immediately

        [OperationContract(IsOneWay = false)] // IsOneWay is false by default
        string RequestReplyOperation();

        [OperationContract]
        string RequestReplyOperation_ThrowsException();
    }
}
