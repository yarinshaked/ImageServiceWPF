using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ImageServiceWPF.JSonTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImageServiceWPF.Client
{
    class ClientConnection : IClientConnection
    {
        private static ClientConnection clientInstance;
        private TcpClient client;
        private IPEndPoint ep;
        NetworkStream stream;
        JSonParse parser;

        public static ClientConnection Instance
        {
            //singleton implementation
            get
            {
                if (clientInstance == null)
                {
                    clientInstance = new ClientConnection();
                    //clientInstance.IsConnected = Instance.Channel
                }
                return clientInstance;
            }
        }

        public void Connect()
        {
            Task task = new Task(() =>
            {
                try
                {
                    ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                    client = new TcpClient();
                    client.Connect(ep);
                    stream = client.GetStream();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            task.Start();
        }

        public void Disconnect()
        {
            try
            {
                client.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public object Read()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    string jSonString = reader.ReadString();
                    //if log or service
                    //parser = new SettingsInfo()
                    //parser = new LogInfo()
                    return parser.FromStringToObj(jSonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Write(string toWrite)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(toWrite);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
