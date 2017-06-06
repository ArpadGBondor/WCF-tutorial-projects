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
            if (Denominator == 0)
                throw new FaultException("Denominator cannot be ZERO", new FaultCode("DivideByZeroFault"));
            return Numerator / Denominator;
        }
    }
}
