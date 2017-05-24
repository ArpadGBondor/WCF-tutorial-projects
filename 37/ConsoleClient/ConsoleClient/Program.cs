using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();

            int number = client.IncrementNumber();
            Console.WriteLine("Number after 1st call: {0}",number);

            number = client.IncrementNumber();
            Console.WriteLine("Number after 2nd call: {0}", number);

            number = client.IncrementNumber();
            Console.WriteLine("Number after 3rd call: {0}", number);

            Console.ReadLine();
        }
    }
}
