using System;
using System.ServiceModel;

namespace CalculatorService
{
    // Option 2: enable includeExceptionDetailInFaults setting
    // [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            try
            {
                return Numerator / Denominator;
            }
            catch (DivideByZeroException ex)
            {
                DivideByZeroFault divideByZeroFault = 
                    new DivideByZeroFault()
                    {
                        Error = ex.Message,
                        Details = "Denominator cannot be ZERO"
                    };
                throw new FaultException<DivideByZeroFault>(divideByZeroFault);
            }
        }
    }
}
