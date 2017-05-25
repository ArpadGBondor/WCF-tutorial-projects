using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SimpleService.SimpleService)))
            {
                host.Open();
                Console.WriteLine("Service started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
