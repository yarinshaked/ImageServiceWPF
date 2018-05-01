using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.Model
{
    interface IModel
    {
        string ServerIP { get; set; }
        int ServerPort { get; set; }
        void connect(string ip, int port);
        void write(string command);
        string read();
        void disconnect();
    }
}
