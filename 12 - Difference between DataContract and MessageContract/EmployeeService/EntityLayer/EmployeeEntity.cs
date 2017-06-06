using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityLayer
{
    // Option 1: Use KnownType attribute on the base type.
    //[KnownType(typeof(FullTimeEmployeeEntity))]
    //[KnownType(typeof(PartTimeEmployeeEntity))]
    [DataContract(Namespace = "http://pragimtech.com/Employee")]
    // Data contract change effects on existing clients:
        // New non-required member: client wont send data, new member is set to its default value by the server
        // New required member: exception occured because the client does not send data
        // Removing non required member: Client continue to send data, the service ignores the data -> data loss
        // Removing required data: Exception occures when the client recives from the service with missing values.
        // Modify existing member data types: If the types are not compatible, exception occures.

    [Table("Employees")]
    public class EmployeeEntity
    {
        [DataMember(Name = "ID", Order = 1,IsRequired = true)]
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        [Column(TypeName = "DateTime2")]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }

        // New member
        [DataMember(Order = 6/*, IsRequired = true*/)]
        public string City { get; set; }
    }
    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}