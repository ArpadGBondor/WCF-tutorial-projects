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
            for (int i = 1; i <= 3; i++)
            {
                SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();

                for (int j = 1; j <= 3; j++)
                {
                    int number = client.IncrementNumber();
                    Console.WriteLine("Session: {0} Call: {1} Number: {2}",i,j, number);
                }
            }

            Console.ReadLine();
        }
    }
}
