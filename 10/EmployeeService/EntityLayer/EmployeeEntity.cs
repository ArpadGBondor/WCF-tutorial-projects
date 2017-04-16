using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EntityLayer
{
    [MessageContract(IsWrapped = true, WrapperName = "EmployeeRequestObject", WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://MyCompany.com/Employee")]
        public string LicenceKey { get; set; }

        [MessageBodyMember(Namespace = "http://MyCompany.com/Employee")]
        public int EmployeeID { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeInfo
    {
        public EmployeeInfo() { }

        public EmployeeInfo(EmployeeEntity employee)
        {
            if (employee != null)
            {
                this.ID = employee.Id;
                this.Name = employee.Name;
                this.Gender = employee.Gender;
                this.DOB = employee.DateOfBirth;
                this.Type = employee.Type;
                if (this.Type == EmployeeType.FullTimeEmployee)
                {
                    this.AnnualSalary = ((FullTimeEmployeeEntity)employee).AnnualSalary;
                }
                else
                {
                    this.HourlyPay = ((PartTimeEmployeeEntity)employee).HourlyPay;
                    this.HoursWorked = ((PartTimeEmployeeEntity)employee).HoursWorked;
                }
            }
            else
            {
                Type = EmployeeType.Null;
            }
        }
        public EmployeeEntity ToEmployeeEntity()
        {
            EmployeeEntity employee;
            if (this.Type == EmployeeType.FullTimeEmployee)
            {
                employee = 
                    new FullTimeEmployeeEntity()
                        {
                            AnnualSalary = this.AnnualSalary
                        };
            }
            else if (this.Type == EmployeeType.PartTimeEmployee)
            {
                employee = 
                    new PartTimeEmployeeEntity()
                        {
                            HourlyPay = this.HourlyPay,
                            HoursWorked = this.HoursWorked
                        };
            }
            else // just in case ...
            {
                employee = new EmployeeEntity();
            }
            employee.Id             = this.ID;
            employee.Name           = this.Name;
            employee.Gender         = this.Gender;
            employee.DateOfBirth    = this.DOB;
            employee.Type           = this.Type;
            return employee;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://MyCompany.com/Employee")]
        public int ID { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://MyCompany.com/Employee")]
        public string Name { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://MyCompany.com/Employee")]
        public string Gender { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://MyCompany.com/Employee")]
        public DateTime DOB { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://MyCompany.com/Employee")]
        public EmployeeType Type { get; set; }
        [MessageBodyMember(Order = 6, Namespace = "http://MyCompany.com/Employee")]
        public int AnnualSalary { get; set; }
        [MessageBodyMember(Order = 7, Namespace = "http://MyCompany.com/Employee")]
        public int HourlyPay { get; set; }
        [MessageBodyMember(Order = 8, Namespace = "http://MyCompany.com/Employee")]
        public int HoursWorked { get; set; }
    }


    // KnownType Option 1: Use KnownType attribute on the base type.
    //[KnownType(typeof(FullTimeEmployeeEntity))]
    //[KnownType(typeof(PartTimeEmployeeEntity))]
    [DataContract(Namespace = "http://MyCompany.com/Employee")]
    [Table(Name = "Employees")]
    public class EmployeeEntity
    {
        [DataMember(Order = 1)]
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
        PartTimeEmployee = 2,
        Null = 0
    }
}