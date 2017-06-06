using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISimpleService
    {
        [OperationContract]
        int IncrementNumber();
    }
}
