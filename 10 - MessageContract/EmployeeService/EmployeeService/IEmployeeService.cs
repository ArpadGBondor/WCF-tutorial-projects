using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EntityLayer;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.

    // KnownType Option 2: Apply ServiceKnownType attribute on the ServiceContract 
    //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
    //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
    [ServiceContract]
    public interface IEmployeeService
    {
        // KnownType Option 3: Apply ServiceKnownType attribute on specific OperationContracts
        //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
        //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
        [OperationContract]
        EmployeeInfo GetEmployee(EmployeeRequest request);

        //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
        //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
        [OperationContract]
        void SaveEmployee(EmployeeInfo employee);

    }
}
