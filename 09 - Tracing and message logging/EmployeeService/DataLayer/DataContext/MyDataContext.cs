using EntityLayer;
using System.Data.Entity;

namespace DataLayer
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public MyDataContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}