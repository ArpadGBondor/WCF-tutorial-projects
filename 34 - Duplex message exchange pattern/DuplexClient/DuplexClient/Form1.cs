using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace DuplexClient
{
    // Option 1: Resolve deadlock
        // Check service too
    // [CallbackBehavior(UseSynchronizationContext = false)]
    // We don't need this if we use One-way Message Exchange Pattern
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Progress(int percentageCompleted)
        {
            try
            {
                TextBox.CheckForIllegalCrossThreadCalls = false;
                textBox1.Text = percentageCompleted.ToString() + " percentage completed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(percentageCompleted.ToString() + " percentage error:\n" + ex.Message);
            }
        }

        private void btnProcessReport_Click(object sender, EventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();
        }
    }
}
