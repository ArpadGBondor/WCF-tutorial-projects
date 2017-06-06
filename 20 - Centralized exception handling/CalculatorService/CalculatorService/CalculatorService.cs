using System;
using System.ServiceModel;

namespace CalculatorService
{
    // Option 2: enable includeExceptionDetailInFaults setting
    // [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    
    // Step 3: Centralized exception handling.
    // Decorate CalculatorService class with GlobalErrorHandlerBehaviourAttribute.
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            //try
            //{
                return Numerator / Denominator;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    DivideByZeroFault divideByZeroFault =
            //        new DivideByZeroFault()
            //        {
            //            Error = ex.Message,
            //            Details = "Denominator cannot be ZERO"
            //        };
            //    throw new FaultException<DivideByZeroFault>(divideByZeroFault);
            //}
        }
    }
}
