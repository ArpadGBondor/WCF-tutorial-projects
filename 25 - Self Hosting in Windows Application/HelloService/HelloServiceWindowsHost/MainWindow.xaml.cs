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

namespace HelloServiceWindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceHost host;

        public MainWindow()
        {
            InitializeComponent();

            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            btnRun.IsEnabled = false;
            btnStop.IsEnabled = true;
            lblResult0.Text = "Service started.";
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            btnRun.IsEnabled = false;
            btnStop.IsEnabled = true;
            lblResult0.Text = "Service started.";
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            host.Close();
            btnRun.IsEnabled = true;
            btnStop.IsEnabled = false;
            lblResult0.Text = "Service stopped.";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            host.Close();
            btnRun.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
    }
}
