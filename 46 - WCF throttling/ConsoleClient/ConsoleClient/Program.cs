using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleService.SimpleServiceClient client =
                new SimpleService.SimpleServiceClient();
            for (int i = 1; i <= 100; i++)
            {
                Thread thread = new Thread(client.DoWork);
                thread.Start();
            }
        }
    }
}
