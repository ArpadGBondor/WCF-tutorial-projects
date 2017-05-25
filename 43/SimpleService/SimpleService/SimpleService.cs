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
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.PerSession)]
    public class SimpleService : ISimpleService
    {
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
