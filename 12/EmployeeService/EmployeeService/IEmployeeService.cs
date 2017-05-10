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

    // Option 2: Apply ServiceKnownType attribute on the ServiceContract 
    //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
    //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
    [ServiceContract]
    public interface IEmployeeService
    {
        // Option 3: Apply ServiceKnownType attribute on specific OperationContracts
        //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
        //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
        [OperationContract]
        EmployeeEntity GetEmployee(int id);

        // Operation contract change effects on existing clients:
            // New parameter is inicialized to it's default value, if the client doesn't know about it. It does not break the existing client.
            // Removed parameter does not break the client, the server just ignores the extra parameter. Possible data loss.
            // Parameter or return type change does not break the client, if conversion is possible between the types. Exception occures otherwise.
            // New operations: Client is not effected. It won't invoke operation it knows nothing about.
            // Removed operation: Exception occures


        //[ServiceKnownType(typeof(PartTimeEmployeeEntity))]
        //[ServiceKnownType(typeof(FullTimeEmployeeEntity))]
        [OperationContract]
        void SaveEmployee(EmployeeEntity employee);

    }
}
