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

        // OneWay Message Exchange Pattern:
        //  - only one message is exchanged between the client and the service.
        //    The client makes a call to the service method, but does not wait 
        //    for a response message. So in short, the reciever of the message 
        //    does not send a reply message, nor does the sender of the message 
        //    excepts one. 
        //  - Faults does not get reported.
        //  - Clients are unaware of the server channel faults until a subsequent 
        //    call is made
        //  - Compile time exception occures if OneWay operations declare output 
        //    parameter, by reference parameter, or return value.

        // OneWay Vs. Asynchronous calls
        //    When a oneway call is recieved at the service, and if the service 
        //    is busy serving other requests, then the call gets queued and the 
        //    client is unblocked and can continue executing while the service 
        //    processes the operation in the background. One-way calls CAN still 
        //    block the client, if the number of messages waiting to be processed 
        //    has exceeded the server queue limit. So, OneWay calls are not 
        //    asynchronous calls, they just appear to be asynchronous.
        [OperationContract(IsOneWay = true)]
        void OneWayOperation();

        [OperationContract(IsOneWay = true)]
        void OneWayOperation_ThrowsException();
    }
}
