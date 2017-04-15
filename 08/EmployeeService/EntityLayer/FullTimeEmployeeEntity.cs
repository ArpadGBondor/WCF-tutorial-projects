using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FullTimeEmployeeEntity : EmployeeEntity
    {
        public FullTimeEmployeeEntity() { Type = EmployeeType.FullTimeEmployee; }
        public int AnnualSalary { get; set; }
    }
}
