using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Reflection;

namespace DataLayer
{
    public class EmployeeProvider
    {
        private static string connectionString;
        private static string server;
        private static string dbName;
        private static string directory;
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
        static EmployeeProvider()
        {
            // Use LocalDB, and create a Database.mdf file in the 
            // aplication folder if it does not exist. 
            server = "(LocalDB)\\MSSQLLocalDB";
            directory = BaseDir;
            dbName = "Database";
            connectionString = "Data Source=" + server + ";AttachDbFilename=\"" + directory + dbName + ".mdf\";Initial Catalog = " + MyDataContext.Generate_Identifier_Name(directory, dbName) + ";Integrated Security=True;";
            
            // If MDF file does not exist, create database
            if (!File.Exists(directory + dbName + ".mdf"))
                using (MyDataContext db = new MyDataContext("Data Source=" + server + ";"))
                {
                    if (!db.CreateDatabase(directory, dbName))
                        throw new ApplicationException("Database creation error");
                }
            // If Datatable does not exist, create and initialize it. 
            using (MyDataContext db = new MyDataContext(connectionString))
            {
                if (!db.DatabaseExists())
                    throw new ApplicationException("Database connection error. ConnectionString: " + connectionString);
                if (!db.TableExists<EmployeeEntity>())
                {
                    db.CreateTable<EmployeeEntity>();
                    db.Employees.InsertOnSubmit(
                        new EmployeeEntity()
                        {
                            Id = 1,
                            Name = "Mark",
                            Gender = "Male",
                            DateOfBirth = DateTime.Parse("10/10/1980")
                        });
                    db.Employees.InsertOnSubmit(
                        new EmployeeEntity()
                        {
                            Id = 2,
                            Name = "Mary",
                            Gender = "Female",
                            DateOfBirth = DateTime.Parse("11/10/1981")
                        });
                    db.Employees.InsertOnSubmit(
                        new EmployeeEntity()
                        {
                            Id = 3,
                            Name = "John",
                            Gender = "Male",
                            DateOfBirth = DateTime.Parse("8/10/1979")
                        });
                    db.SubmitChanges();
                }
            }
        }

        public static bool Test()
        {
            bool lTest;
            using (MyDataContext db = new MyDataContext(connectionString))
            {
                lTest = db.DatabaseExists();
            }
            return lTest;
        }
        
        public static bool SaveEmployee(EmployeeEntity employee)
        {
            bool lSuccess = false;
            bool lExist = false;
            using (MyDataContext db = new MyDataContext(connectionString))
            {
                var query = db.Employees.Where(p => (p.Id == employee.Id));
                foreach(var rec in query)
                {
                    // Update all property
                    PropertyInfo[] properties = typeof(EmployeeEntity).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(rec, property.GetValue(employee));
                    }
                    lExist = true;
                }

                if (!lExist)
                {
                    // Insert record
                    db.Employees.InsertOnSubmit(employee);
                }

                try
                {
                    db.SubmitChanges();
                    lSuccess = true;
                }
                catch { }
            }
            return lSuccess;
        }
        //public static bool AddEmployee(EmployeeEntity employee)
        //{
        //    bool lSuccess = false;
        //    using (MyDataContext db = new MyDataContext(connectionString))
        //    {
        //        db.Employees.InsertOnSubmit(employee);
        //        try
        //        {
        //            db.SubmitChanges();
        //            lSuccess = true;
        //        }
        //        catch { }
        //    }
        //    return lSuccess;
        //}
        public static EmployeeEntity GetEmployee(int id)
        {
            EmployeeEntity employee;
            using (MyDataContext db = new MyDataContext(connectionString))
            {
                employee = db.Employees.Where(p => p.Id == id).FirstOrDefault();
            }
            return employee;
        }
    }
}
