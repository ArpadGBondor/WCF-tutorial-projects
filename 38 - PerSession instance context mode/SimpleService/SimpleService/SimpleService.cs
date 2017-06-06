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

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    //Session: 1 Call: 1 Number: 1
    //Session: 1 Call: 2 Number: 2
    //Session: 1 Call: 3 Number: 3
    //Session: 2 Call: 1 Number: 1
    //Session: 2 Call: 2 Number: 2
    //Session: 2 Call: 3 Number: 3
    //Session: 3 Call: 1 Number: 1
    //Session: 3 Call: 2 Number: 2
    //Session: 3 Call: 3 Number: 3
    // Implications of PerSession WCF service
    // - State maintained between calls
    // - Greater memory consumption as service objects remain in memory until 
    //   the client session times out. This negatively affects application scalability.
    // - Concurrency is an issue for multi-threaded clients
    // - Session timeout: 10 min

    // How do you design a WCF service? Would you design it as a PerCall service or 
    // PerSession service?
    //  - PerCall and PerSession services have different strengths and weaknesses.
    //  - If you prefer using object oriented programmong style, then PerSession 
    //    is your choice. On the other hand if you prefer SOA (Service Oriented 
    //    Architecture) style, then PerCall is your choice.
    //  - In general, all things being equal, the trade-off is performance vs scalability.
    //    PerSession services perform better because the service object does not have to 
    //    be instantiated on subsequent requests. PerCall services scale better because
    //    the service objects are destroyed immediately after the method call returns.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
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
