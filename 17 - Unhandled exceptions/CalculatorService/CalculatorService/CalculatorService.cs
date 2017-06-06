using System.ServiceModel;

namespace CalculatorService
{
    // Option 2: enable includeExceptionDetailInFaults setting
    // [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            return Numerator / Denominator;
        }
    }
}
