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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Number = " + client.IncrementNumber().ToString());
        }
    }
}
