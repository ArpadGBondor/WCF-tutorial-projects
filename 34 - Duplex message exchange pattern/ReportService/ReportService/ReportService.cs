using System;
using System.ServiceModel;
using System.Threading;

namespace ReportService
{
    // Option 1: Resolve deadlock
        // Check client too
    // [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)] 
    // We don't need this if we use One-way Message Exchange Pattern

    public class ReportService : IReportService
    {
        public void ProcessReport()
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    Console.WriteLine(i.ToString() + " percentage completed.");
                    OperationContext.Current.GetCallbackChannel<IReportServiceCallBack>().Progress(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
