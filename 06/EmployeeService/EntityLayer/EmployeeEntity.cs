using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace EntityLayer
{
    [DataContract(Namespace = "http://pragimtech.com/Employee")]
    [Table(Name = "Employees")]
    public class EmployeeEntity
    {
        [DataMember(Name = "ID", Order = 1)]
        [Column(IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        [Column]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        [Column]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        [Column(DbType = "DateTime2")]
        public DateTime DateOfBirth { get; set; }
    }
}