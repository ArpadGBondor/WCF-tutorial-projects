using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //    Console.WriteLine(DataLayer.EmployeeProvider.GetEmployee(i) == null ? " - null - " : DataLayer.EmployeeProvider.GetEmployee(i).Name);
            if (DataLayer.EmployeeProvider.Test())
            {
                using (ServiceHost host = new ServiceHost(typeof(EmployeeService.EmployeeService)))
                {
                    host.Open();
                    Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                    Console.ReadLine();
                }
            }
        }
    }
}
