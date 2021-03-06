﻿using System;
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
            try
            {
                MessageBox.Show("Number = " + client.IncrementNumber().ToString() + "\nSession ID: " + client.InnerChannel.SessionId);
            }
            catch(System.ServiceModel.CommunicationException ex)
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    MessageBox.Show("Session timed out. Your existing session will be lost. A new session will now be created.");
                    client = new SimpleService.SimpleServiceClient();
                }
            }
        }
    }
}
