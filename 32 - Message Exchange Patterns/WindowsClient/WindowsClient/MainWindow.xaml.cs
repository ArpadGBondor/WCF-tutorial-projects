using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;

namespace WindowsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleService.SimpleServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
        }

        private void Log(string text)
        {
            listBox1.Items.Add(text);
        }

        private void btnRequest1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("Request-Reply Operation Started @ " + DateTime.Now.ToString());
                // In WPF disableing the button is useless
                // btnRequest1.IsEnabled = false;
                Log(client.RequestReplyOperation());
                // btnRequest1.IsEnabled = true;
                Log("Request-Reply Operation Completed @ " + DateTime.Now.ToString());
                Log("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRequest2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("Request-Reply Operation Started @ " + DateTime.Now.ToString());
                Log(client.RequestReplyOperation_ThrowsException());
                Log("Request-Reply Operation Completed @ " + DateTime.Now.ToString());
                Log("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
