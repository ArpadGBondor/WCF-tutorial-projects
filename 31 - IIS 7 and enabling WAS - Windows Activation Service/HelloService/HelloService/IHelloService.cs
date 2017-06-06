using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HelloService
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}
