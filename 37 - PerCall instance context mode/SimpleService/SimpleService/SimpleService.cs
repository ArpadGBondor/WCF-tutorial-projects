using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    //Number after 1st call: 1
    //Number after 2nd call: 1
    //Number after 3rd call: 1
    // Implications of PerCall WCF service:
    //  - Better memory usage as service objects are freed immediately after
    //    method call returns
    //  - Concurency is not an issue
    //  - Application scalability is better
    //  - State is not maintained between calls
    //  - Performance could be an issue as there is overhead involved in 
    //    reconstructing the service instance state on each and every method call

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        private int _number;

        public int IncrementNumber()
        {
            _number = _number + 1;
            return _number;
        }
    }
}
