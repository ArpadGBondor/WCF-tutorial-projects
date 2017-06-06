using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    public class EmployeeProvider
    {
        static EmployeeProvider()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                // Create database if not exists
                using (var contextDB = new MyDataContext(connection, false))
                {
                    contextDB.Database.CreateIfNotExists();
                }
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var context = new MyDataContext(connection, false))
                    {
                        // Passing an existing transaction to the context
                        context.Database.UseTransaction(transaction);

                        if (context.Employees.Count() == 0)
                        {
                            context.Employees.Add(
                                new FullTimeEmployeeEntity()
                                {
                                    Id = 1,
                                    Name = "Mark",
                                    Gender = "Male",
                                    DateOfBirth = DateTime.Parse("10/10/1980"),
                                    AnnualSalary = 50000
                                });
                            context.Employees.Add(
                                new PartTimeEmployeeEntity()
                                {
                                    Id = 2,
                                    Name = "Mary",
                                    Gender = "Female",
                                    DateOfBirth = DateTime.Parse("11/10/1981"),
                                    HoursWorked = 20,
                                    HourlyPay = 10
                                });
                            context.Employees.Add(
                                new FullTimeEmployeeEntity()
                                {
                                    Id = 3,
                                    Name = "John",
                                    Gender = "Male",
                                    DateOfBirth = DateTime.Parse("8/10/1979"),
                                    AnnualSalary = 20000
                                });

                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    throw exc;
                }
            }          
        }

        public static bool Test()
        {
            bool lTest;
            using (MyDataContext context = new MyDataContext(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                lTest = context.Database.Exists();
            }
            return lTest;
        }
        
        public static bool SaveEmployee(EmployeeEntity employee)
        {
            bool lSuccess = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (var context = new MyDataContext(connection, false))
                    {
                        // Passing an existing transaction to the context
                        context.Database.UseTransaction(transaction);

                        var query = context.Employees.Where(p => (p.Id == employee.Id));
                        foreach(var rec in query)
                        {
                            // Delete record
                            context.Employees.Remove(rec);
                        }
                        // Insert record
                        context.Employees.Add(employee); 
                        context.SaveChanges();
                    }
                    transaction.Commit();
                    lSuccess = true;
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    // throw exc;
                }
            }
            return lSuccess;
        }

        public static EmployeeEntity GetEmployee(int id)
        {
            EmployeeEntity employee = null;
            using (MyDataContext context = new MyDataContext(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                foreach (var rec in context.Employees.Where(p => p.Id == id))
                {
                    employee = rec;
                }
            }
            return employee;
        }
    }
}
