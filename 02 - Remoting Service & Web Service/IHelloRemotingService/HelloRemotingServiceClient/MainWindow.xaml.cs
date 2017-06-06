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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace HelloRemotingServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IHelloRemotingService.IHelloRemotingService client;
        public MainWindow()
        {
            InitializeComponent();
            TcpChannel channel = new TcpChannel();
            client = (IHelloRemotingService.IHelloRemotingService)Activator.GetObject
                (typeof(IHelloRemotingService.IHelloRemotingService),
                "tcp://localhost:8090/GetMessage");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = client.GetMessage(TextBox1.Text);
        }
    }
}
