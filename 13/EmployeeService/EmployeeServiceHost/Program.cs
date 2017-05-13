using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EntityLayer;
using System.Data.Entity;
using DataLayer;

namespace EmployeeServiceHost
{
    class Program
    {
        private static string BaseDir
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                if (!baseDir.EndsWith("\\"))
                    baseDir += "\\";
                return baseDir;
            }
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", BaseDir);

            //DataLayer.EmployeeProvider.SaveEmployee(
            //    new FullTimeEmployeeEntity()
            //    {
            //        Id = 8,
            //        Name = "Bela",
            //        DateOfBirth = DateTime.Now,
            //        Gender = "Not sure",
            //        AnnualSalary = 15000                    
            //    });
            //DataLayer.EmployeeProvider.SaveEmployee(
            //    new PartTimeEmployeeEntity()
            //    {
            //        Id = 8,
            //        Name = "Lajos",
            //        DateOfBirth = DateTime.Now,
            //        Gender = "Not sure",
            //        HourlyPay = 15,
            //        HoursWorked = 4
            //    });
            //for (int i = 0; i < 20; i++)
            //{
            //    var employee = DataLayer.EmployeeProvider.GetEmployee(i);
            //    if (employee == null)
            //    {
            //        Console.WriteLine(" - null - ");
            //    }
            //    else if (employee.Type == EntityLayer.EmployeeType.FullTimeEmployee)
            //    {
            //        Console.WriteLine("Name: {0}, Salary: {1}", employee.Name, ((FullTimeEmployeeEntity)employee).AnnualSalary);
            //    }
            //    else if (employee.Type == EntityLayer.EmployeeType.PartTimeEmployee)
            //    {
            //        Console.WriteLine("Name: {0}, Hourly: {1}", employee.Name, ((PartTimeEmployeeEntity)employee).HourlyPay);
            //    }
            //}
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
