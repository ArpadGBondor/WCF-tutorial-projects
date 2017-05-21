using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WindowsServiceHost
{
    public partial class HelloWindowsService : ServiceBase
    {
        ServiceHost host;
        public HelloWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
