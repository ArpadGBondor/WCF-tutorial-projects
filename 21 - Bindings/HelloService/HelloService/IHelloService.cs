using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloService
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}
