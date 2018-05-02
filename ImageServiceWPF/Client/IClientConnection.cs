using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.Client
{
    interface IClientConnection
    {
        void connect();
        void disconnect();
        void write(string toWrite);
        string read();
    }
}
