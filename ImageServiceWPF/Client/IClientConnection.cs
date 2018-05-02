using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.Client
{
    interface IClientConnection
    {
        void Connect();
        void Disconnect();
        void Write(object toWrite);
        object Read();
    }
}
