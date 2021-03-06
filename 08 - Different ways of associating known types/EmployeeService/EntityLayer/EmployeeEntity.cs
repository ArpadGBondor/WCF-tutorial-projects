﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace EntityLayer
{
    // Option 1: Use KnownType attribute on the base type.
    //[KnownType(typeof(FullTimeEmployeeEntity))]
    //[KnownType(typeof(PartTimeEmployeeEntity))]
    [DataContract(Namespace = "http://pragimtech.com/Employee")]
    [Table(Name = "Employees")]
    public class EmployeeEntity
    {
        [DataMember(Name = "ID", Order = 1)]
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        [Column(DbType = "DateTime2")]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }
    }
    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }
}