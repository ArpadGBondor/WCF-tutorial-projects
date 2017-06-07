using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Security;

namespace HelloService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloService" in both code and config file together.
    [ServiceContract]
    public interface IHelloService
    {
        ////  Original
        //[OperationContract]
        //string GetMessage(string message);

        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        string GetMessageWithoutAnyProtection();

        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        string GetSignedMessage();

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        string GetSignedAndEncryptedMessage();
    }
}
