using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    // Step 1: Centralized exception handling.
    // Implement IErrorHandler interface
    class GlobalErrorHandler : IErrorHandler
    {
        // This method gets called automatically when there is an unhandled exception
        // or a fault. In this method we have the opportunity to write code to convert
        // the unhandled exception into a generic fault that can be returned to the client.
        // ProvideFault gets called before HandleError method.
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            FaultException faultException = new FaultException("A general service error occured");
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }

        // This method gets called asynchronously after ProvideFault() method is called
        // and the error message is returned to the client. This means that this method 
        // allows us to write code to log the exception without blocking the client call.
        public bool HandleError(Exception error)
        {
            // log the actual exception here for the IT Team to investigate
            // return true to indicate that the exception is handled.
            return true;
        }

    }
}
