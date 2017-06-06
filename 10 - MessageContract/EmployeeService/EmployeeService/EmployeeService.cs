using DataLayer;
using EntityLayer;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public EmployeeInfo GetEmployee(EmployeeRequest request)
        {
            return new EmployeeInfo(EmployeeProvider.GetEmployee(request.EmployeeID));
        }

        public void SaveEmployee(EmployeeInfo employee)
        {
            EmployeeProvider.SaveEmployee(employee.ToEmployeeEntity());
        }
    }
}
