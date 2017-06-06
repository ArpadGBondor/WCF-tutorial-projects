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

namespace WindowsFormsClient
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
            Label.CheckForIllegalCrossThreadCalls = false;
        }

        public void ReportProgress(int percentageCompleted)
        {
            try
            {
                lblPercentageDone.Text = percentageCompleted.ToString() + "% completed";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnServiceCall_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();
            lblResult.Text = "Report processed.";
        }


    }
}
