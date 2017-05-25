using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    //     Number after 1st call: 1
    //     Number after 2nd call: 1
    //     Number after 3rd call: 1
    //    Implications of PerCall WCF service:
    //     - Better memory usage as service objects are freed immediately after
    //       method call returns
    //     - Concurency is not an issue
    //     - Application scalability is better
    //     - State is not maintained between calls
    //     - Performance could be an issue as there is overhead involved in 
    //       reconstructing the service instance state on each and every method call

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    //     Session: 1 Call: 1 Number: 1
    //     Session: 1 Call: 2 Number: 2
    //     Session: 1 Call: 3 Number: 3
    //     Session: 2 Call: 1 Number: 1
    //     Session: 2 Call: 2 Number: 2
    //     Session: 2 Call: 3 Number: 3
    //     Session: 3 Call: 1 Number: 1
    //     Session: 3 Call: 2 Number: 2
    //     Session: 3 Call: 3 Number: 3
    //    Implications of PerSession WCF service
    //     - State maintained between calls
    //     - Greater memory consumption as service objects remain in memory until
    //       the client session times out. This negatively affects application scalability.
    //     - Concurrency is an issue for multi-threaded clients
    //     - Session timeout: 10 min

    //     Does all binding support sessions?
    //      - No, not all binding support sessions.For example basicHttpBinding does not
    //       support session.If the binding does not support session, then the service
    //        behaves as a PerCall service.

    //     How to control WCF service session timeout?
    //      - The default session timeout is 10 minutes.If you want to increase or decrease
    //       the default timeout value, set recieveTimeout attribute of the respective binding
    //        element. -> Check the config file.

    //     What happens when the session timeout is reached
    //      - When the session timeout is reached, the connection to the WCF service is closed.
    //        As a result, the communication channel gets faultes and the client can no longer
    //        use the same proxy instance to communicate with the service.This also means that
    //        the session, the data in the service object is also lost.
    //      - On first attempt to invoke the service using the same proxy instance would result 
    //        in the following exception:
    //           The socket connection was aborted.This could be caused by an error processing
    //           your message or a receive timeout being exceeded by the remote host, or an
    //           underlying network resource issue.Local socket timeout was '00:00:59.9709983
    //      - On the second attempt the following exception will be thrown:
    //           The communication object, System.ServiceModel.Channels.ServiceChannel, cannot
    //           be used for communication because it is in Faulted state.

    //     Session ID
    //      - retriece from client: proxyClassInstance.InnerChannel.SessionId
    //      - retrieve from the WCF service: OperationContext.Current.SessionId
    //      - The client-side and service-side session IDs are co-related using the reliable
    //        session id.So, if TCP binding is being used with reliable sessions disabled then
    //       the client and server session id'd will be different. On the other hand, if reliable
    //        sessions are enabled, the session id's will be the same.
    //      - With wsHttpBinding, irrespective of whether reliable sessions are enabled or not,
    //        the session id's will be the same.

    //     How do you design a WCF service? Would you design it as a PerCall service or
    //     PerSession service?
    //      - PerCall and PerSession services have different strengths and weaknesses.
    //      - If you prefer using object oriented programmong style, then PerSession 
    //        is your choice.On the other hand if you prefer SOA (Service Oriented
    //        Architecture) style, then PerCall is your choice.
    //      - In general, all things being equal, the trade-off is performance vs scalability.
    //        PerSession services perform better because the service object does not have to
    //        be instantiated on subsequent requests. PerCall services scale better because
    //        the service objects are destroyed immediately after the method call returns.

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    //     Session: 1 Call: 1 Number: 1
    //     Session: 1 Call: 2 Number: 2
    //     Session: 1 Call: 3 Number: 3
    //     Session: 2 Call: 1 Number: 4
    //     Session: 2 Call: 2 Number: 5
    //     Session: 2 Call: 3 Number: 6
    //     Session: 3 Call: 1 Number: 7
    //     Session: 3 Call: 2 Number: 8
    //     Session: 3 Call: 3 Number: 9
    //    Implications of creating a WCF service with Single instance context mode
    //     - Since a single service instance is serving all client requests, state is maintained 
    //       and shared not only between requests from the same client but also between different
    //       clients.
    //     - Concurrency is an issue
    //     - Throughput can be an issue. To fix concurrency issue, we can configure the service to 
    //       allow only a single thread to access the service instance. But the moment we do it 
    //       throughput becomes an issue as other requests queue up and wait for the current thread
    //       to finnish it's work.

    //    Session mode: [ServiceContract(SessionMode = SessionMode.Allowed)]
    //        Use SesionMode enumeration with the Service Contract to require, allow or prohibit 
    //        bindings to use sessions.
    //         - Allowed: Service contract supports sessions if the binding supports them. This is 
    //           the default if we have not explicitly specified the SessionMode on Service contract.
    //         - NotAllowed: Service contract does not support bindings that initiate sessions.
    //         - Required: Service contract requires a binding that supports session.
    //    MSDN article: https://msdn.microsoft.com/en-us/library/system.servicemodel.sessionmode(v=vs.110).aspx
    //
    //    Example 1: Set the service InstanceContextMode to Single and SessionMode to Allowed.
    //      - If we use basicHttpBinding that does not support sessions, the service still works as 
    //        a singleton service but without session.
    //      - On the other hand if we use, netTcpBinding that supports sessions, the service gets 
    //        a session, and continue to work as a singleton service.    
    //    Example 2: Now change the SessionMode to Required
    //      - If we use, netTcpBinding that support sessions, the service sets a session, and 
    //        continue to work as a singleton service.
    //      - On the other hand, if we use basicHttpBinding that does not support sessions,
    //        the following exception is thrown
    //            System.InvalidOperationException: Contract requires Session, but Binding 
    //            'basicHttpBinding' doesn't support it or isn't configured to properly support it.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SimpleService : ISimpleService
    {
        private int _number;

        public int IncrementNumber()
        {
            System.Console.WriteLine("Session ID: " + OperationContext.Current.SessionId);
            _number = _number + 1;
            return _number;
        }
    }
}
