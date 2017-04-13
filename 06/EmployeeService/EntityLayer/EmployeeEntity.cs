using System;
using System.Data.Linq.Mapping;

namespace EntityLayer
{
    [Table(Name = "Employees")]
    public class EmployeeEntity
    {
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Gender { get; set; }

        [Column(DbType = "DateTime2")]
        public DateTime DateOfBirth { get; set; }
    }
}