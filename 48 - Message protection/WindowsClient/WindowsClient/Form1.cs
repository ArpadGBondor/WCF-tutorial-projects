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
        HelloService.HelloServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HelloService.HelloServiceClient();
        }

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    HelloService.HelloServiceClient client =
        //        new HelloService.HelloServiceClient();
        //    lblResult.Text = client.GetMessage(txtName.Text);
        //    MessageBox.Show(lblResult.Text);
        //}



        private void btnGet1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetMessageWithoutAnyProtection());
        }

        private void btnGet2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetSignedMessage());
        }

        private void btnGet3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetSignedAndEncryptedMessage());
        }
    }
}
