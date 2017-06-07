using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            SimpleService.SimpleServiceClient client =
                new SimpleService.SimpleServiceClient();
            MessageBox.Show(client.GetMessage("Windows username and password required here."));
            client.ClientCredentials.UserName.UserName = "******"; // Windows username required
            client.ClientCredentials.UserName.Password = "******"; // Windows password required
            MessageBox.Show(client.GetMessage("Red"));
        }
    }
}
