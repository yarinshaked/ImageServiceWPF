using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImageServiceWPF.Model
{
    class SettingsModel : IModel
    {
        private TcpClient client;

        public string ServerIP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ServerPort { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
        }

        public void disconnect()
        {
            try
            {
                client.Close();
            } catch(Exception)
            {
                throw new Exception();
            }
        }

        public string read()
        {
            return "";
            
        }

        public void write(string command)
        {
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(command);
        }
    }
}
