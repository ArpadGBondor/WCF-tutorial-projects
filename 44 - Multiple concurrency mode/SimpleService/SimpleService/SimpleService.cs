using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
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



        public List<int> GetEvenNumbers()
        {
            Console.WriteLine("Thread {0} started processing GetEvenNumbers at {1}", Thread.CurrentThread.ManagedThreadId,DateTime.Now.ToString());
            List<int> listEvenNumbers = new List<int>();
            for(int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 == 0)
                {
                    listEvenNumbers.Add(i);
                }
            }
            Console.WriteLine("Thread {0} completed processing GetEvenNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listEvenNumbers;
        }

        public List<int> GetOddNumbers()
        {
            Console.WriteLine("Thread {0} started processing GetOddNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            List<int> listOddNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {
                    listOddNumbers.Add(i);
                }
            }
            Console.WriteLine("Thread {0} completed processing GetOddNumbers at {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listOddNumbers;
        }
    }
}
