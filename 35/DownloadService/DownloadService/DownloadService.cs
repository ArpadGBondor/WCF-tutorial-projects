using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    public class DownloadService : IDownloadService
    {
        public File DownloadDocument()
        {
            File file = new File();
            file.Content = System.IO.File.ReadAllBytes(@"C:\Users\Red\Documents\Visual Studio 2015\Projects\WCF-tutorial-projects\35\DownloadService\DownloadService\world.jpg");
            file.Name = "world.jpg";

            return file;
        }
    }
}
