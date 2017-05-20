﻿using System.ServiceModel;

namespace CalculatorService
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [FaultContract(typeof(DivideByZeroFault))]
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}
