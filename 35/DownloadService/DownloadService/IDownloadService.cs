using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    [ServiceContract]
    public interface IDownloadService
    {
        [OperationContract]
        File DownloadDocument();
    }

    [DataContract]
    public class File
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }
}
