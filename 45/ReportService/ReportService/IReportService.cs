using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReportService
{
    [ServiceContract(CallbackContract = typeof(IReportServiceCallBack))]
    public interface IReportService
    {
        [OperationContract]
        void ProcessReport();
    }

    public interface IReportServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ReportProgress(int percentageCompleted);
    }
}
