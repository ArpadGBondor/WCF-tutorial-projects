namespace EntityLayer
{
    public class PartTimeEmployeeEntity : EmployeeEntity
    {
        public PartTimeEmployeeEntity() { Type = EmployeeType.PartTimeEmployee; }
        public int HourlyPay { get; set; }
        public int HoursWorked { get; set; }
    }
}
