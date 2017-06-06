using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HelloServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = 
                new ServiceHost(typeof(HelloService.HelloService)))
            {
                ServiceMetadataBehavior serviceMetadataBehavior =
                    new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true
                    };
                host.Description.Behaviors.Add(serviceMetadataBehavior);
                host.AddServiceEndpoint(
                    typeof(HelloService.IHelloService), // Contract
                    new NetTcpBinding(),                // Binding
                    "HelloService");                    // Address

                host.Open();
                Console.WriteLine("Host started @" + DateTime.Now.ToString());
                Console.ReadLine();
            }

        }
    }
}
