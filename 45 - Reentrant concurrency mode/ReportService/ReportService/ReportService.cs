using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ReportService
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class ReportService : IReportService
    {
        // Instance     Concurrency     Binding     Concurrent      Throughput
        // Context      Mode            support     calls           Impact
        // Mode                         session     processed
        //==========================================================================
        // PerCall      Single          No          Yes             Positive
        //--------------------------------------------------------------------------
        // PerCall      Single          Yes         No              Negative
        //--------------------------------------------------------------------------
        // PerSession   Single          No          Yes             Positive
        //--------------------------------------------------------------------------
        // PerSession   Single          Yes         Yes             Positive (between clients)
        //                                                          Negative (same client requests)
        //--------------------------------------------------------------------------
        // Single       Single          No          No              Negative
        //--------------------------------------------------------------------------
        // Single       Single          Yes         No              Negative
        //==========================================================================
        // PerCall      Multiple        No          Yes             Positive
        //--------------------------------------------------------------------------
        // PerCall      Multiple        Yes         Yes             Positive
        //--------------------------------------------------------------------------
        // PerSession   Multiple        No          Yes             Positive
        //--------------------------------------------------------------------------
        // PerSession   Multiple        Yes         Yes             Positive
        //--------------------------------------------------------------------------
        // Single       Multiple        No          Yes             Positive
        //--------------------------------------------------------------------------
        // Single       Multiple        Yes         Yes             Positive
        //==========================================================================

        // Reentrant concurrency mode in WCF
        //     Reentrant concurrency mode allows the WCF service to issue callbacks 
        //     to the client application
        //
        //     1. The WCF service concurrency mode is set to single. This means only 
        //        one thread is allowed to access the service instance
        //     2. Client makes a request to the WCF Service. The service instance gets 
        //        locked by the thread that is executing the client requests. At this
        //        point no other thread can access the service instance, until the 
        //        current thread has completed and released the lock.
        //     3. While the service instance is processing the client request, the 
        //        service wants to callback the client. The callback operation is not 
        //        one way. This means the response for the callback from the client 
        //        needs to get back to the same service instance, but the service 
        //        instance is locked and the response from the client cannot reenter 
        //        and access the service instance. This situation leads to a deadlock.
        //
        //     There are two ways to resolve the deadlock:
        //     1. Set the concurrency mode of the WCF service to Reentrant
        //     2. Make the callback operation oneway. When the callback operation is 
        //        made oneway, the service is not expecting a response from the client, 
        //        so locking will not be an issue.

        public void ProcessReport()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                OperationContext.Current.GetCallbackChannel<IReportServiceCallBack>().ReportProgress(i);
            }
        }
    }
}
