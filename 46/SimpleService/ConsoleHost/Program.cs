using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SimpleService.SimpleService)))
            {
                //ServiceThrottlingBehavior throttlingBehavior =
                //    new ServiceThrottlingBehavior
                //    {
                //        MaxConcurrentCalls = 3,
                //        MaxConcurrentInstances = 3,
                //        MaxConcurrentSessions = 100
                //    };
                //host.Description.Behaviors.Add(throttlingBehavior);
                host.Open();

                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
