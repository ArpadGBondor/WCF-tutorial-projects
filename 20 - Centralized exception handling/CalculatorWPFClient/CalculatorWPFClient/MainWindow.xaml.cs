using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace CalculatorWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorService.CalculatorServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new CalculatorService.CalculatorServiceClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numerator = Convert.ToInt32(txtNumerator.Text);
                int denominator = Convert.ToInt32(txtDenominator.Text);
                lblResult.Text = client.Divide(numerator, denominator).ToString();
            }
            //catch (FaultException<CalculatorService.DivideByZeroFault> faultException)
            //{
            //    lblResult.Text = faultException.Detail.Error + " - " + faultException.Detail.Details;
            //}
            catch (FaultException faultException)
            {
                lblResult.Text = faultException.Message;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client = new CalculatorService.CalculatorServiceClient();
            MessageBox.Show("A new instance of the proxy class is created");
        }
    }
}
