using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ImageService.Model;
using ImageService.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImageServiceWPF.Client
{
    class ClientConnection : IClientConnection
    {
        public event EventHandler<CommandMessage> DataReceived;
        private static ClientConnection clientInstance;
        private TcpClient client;
        private IPEndPoint ep;
        private bool isStopped;
        NetworkStream stream;

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

        public bool Connect()
        {
            try
            {
                bool result = true;
                ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                client = new TcpClient();
                client.Connect(ep);
                isStopped = false;
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                client.Close();
                isStopped = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Read()
        {
            
            Task task = new Task(() =>
            {
                while (!isStopped)
                {
                    stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);
                    string jSonString = reader.ReadString();
                    CommandMessage msg = CommandMessage.ParseJSON(jSonString);
                    this.DataReceived?.Invoke(this, msg);
                }
            });
            task.Start();

        }

        public void Write(CommandReceivedEventArgs e)
        {
            Task task = new Task(() =>
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {

                    string toSend = JsonConvert.SerializeObject(e);
                    writer.Write(toSend);
                }
            });
            task.Start();
        }
    }
}
