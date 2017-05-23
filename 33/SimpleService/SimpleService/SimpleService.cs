using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleService
{
    public class SimpleService : ISimpleService
    {
        // Request-Reply pattern:
        //    The client sends a message to the WCF service and then waits for
        //    the reply message, even if the service operation's return type is void.
        public string RequestReplyOperation()
        {
            DateTime dtStart = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;

            return dtEnd.Subtract(dtStart).Seconds.ToString() + " secounds processing time";
        }

        public string RequestReplyOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }

        // OneWay Message Exchange Pattern:
        //  - only one message is exchanged between the client and the service.
        //    The client makes a call to the service method, but does not wait 
        //    for a response message. So in short, the reciever of the message 
        //    does not send a reply message, nor does the sender of the message 
        //    excepts one. 
        //  - Faults does not get reported.
        //  - Clients are unaware of the server channel faults until a subsequent 
        //    call is made

        // OneWay Vs. Asynchronous calls
        //    When a oneway call is recieved at the service, and if the service 
        //    is busy serving other requests, then the call gets queued and the 
        //    client is unblocked and can continue executing while the service 
        //    processes the operation in the background. One-way calls CAN still 
        //    block the client, if the number of messages waiting to be processed 
        //    has exceeded the server queue limit. So, OneWay calls are not 
        //    asynchronous calls, they just appear to be asynchronous.
        public void OneWayOperation()
        {
            Thread.Sleep(2000);
            return;
        }

        public void OneWayOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }
    }
}
