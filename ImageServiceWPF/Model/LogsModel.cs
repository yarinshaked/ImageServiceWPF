using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageServiceWPF.Model
{
    class LogsModel : IModel
    {
        public string ServerIP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ServerPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void write(string command)
        {
            throw new NotImplementedException();
        }
    }
}
