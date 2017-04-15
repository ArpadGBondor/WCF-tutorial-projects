using DataLayer;
using EntityLayer;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public EmployeeEntity GetEmployee(int id)
        {
            return EmployeeProvider.GetEmployee(id);
        }

        public void SaveEmployee(EmployeeEntity employee)
        {
            EmployeeProvider.SaveEmployee(employee);
        }
    }
}
