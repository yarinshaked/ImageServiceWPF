using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceWPF.Client
{
    class ClientConnection : IClientConnection
    {
        private TcpClient client;
        private IPEndPoint ep;

        public void connect()
        {
            Task task = new Task(() =>
            {
                try
                {
                    ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                    client = new TcpClient();
                    client.Connect(ep);
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryReader reader = new BinaryReader(stream))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        //writer.Write("GetAppConfig");

                        //change this to JSON
                        /*
                        this.OutputDirectory = reader.ReadString();
                        this.SourceName = reader.ReadString();
                        this.LogName = reader.ReadString();
                        this.ThumbnailSize = reader.ReadInt32();
                        */
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            task.Start();
        }

        public void disconnect()
        {
            try
            {
                client.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string read()
        {
            throw new NotImplementedException();
        }

        public void write(string toWrite)
        {
            throw new NotImplementedException();
        }
    }
}
