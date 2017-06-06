using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleService
{
    public class SimpleService : ISimpleService
    {
        public string RequestReplyOperation()
        {
            DateTime dtStart = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;

            return dtEnd.Subtract(dtStart).Seconds.ToString() + " secounds processing time";
        }

        public string RequestReplyOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }
    }
}
