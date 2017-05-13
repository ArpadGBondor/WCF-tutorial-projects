﻿using DataLayer;
using EntityLayer;
using System.ServiceModel;

namespace EmployeeService
{
    // Option 2: Ignore ExtensionData to prevent Denial of Service attacks
    // [ServiceBehavior(IgnoreExtensionDataObject = true)]

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EmployeeService : IEmployeeService
    {
        private EmployeeEntity _lastSavedEmployee;

        public EmployeeEntity GetEmployee(int id)
        {
            var result = EmployeeProvider.GetEmployee(id);
            if (_lastSavedEmployee != null && id == _lastSavedEmployee.Id)
            {
                result.ExtensionData = _lastSavedEmployee.ExtensionData;
            }

            return result;
        }

        public void SaveEmployee(EmployeeEntity employee)
        {
            _lastSavedEmployee = employee;
            EmployeeProvider.SaveEmployee(employee);
        }
    }
}
