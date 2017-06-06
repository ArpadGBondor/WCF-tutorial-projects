using System.ServiceModel;

namespace ReportService
{
    // Associate callback contract with service contract using CallbackContract attribute
    [ServiceContract(CallbackContract = typeof(IReportServiceCallBack))]
    public interface IReportService
    {
        // Since we have not set IsOneWay=true, the operation is Request/Reply operation
        [OperationContract(IsOneWay = true)]
        void ProcessReport();
    }

    // This is the callback contract
    public interface IReportServiceCallBack
    {
        // Since we have not set IsOneWay=true, the operation is Request/Reply operation
        [OperationContract(IsOneWay = true)]
        void Progress(int percentageCompleted);
    }
}
