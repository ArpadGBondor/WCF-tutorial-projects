using System.ServiceModel;

namespace CalculatorService
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}
