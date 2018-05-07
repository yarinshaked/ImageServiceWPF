﻿using System;
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
        private bool isConnected;

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

        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }
            set
            {
                this.isConnected = value;
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
                isConnected = true;
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
                isConnected = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Read()
        {

            Task<CommandMessage> task = new Task<CommandMessage>(() =>
            {

                stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                string jSonString = reader.ReadLine();
                while (reader.Peek() > 0)
                {
                    jSonString += reader.ReadLine();
                }
                CommandMessage msg = CommandMessage.ParseJSON(jSonString);
                return msg;

            });
            task.Start();
            this.DataReceived?.Invoke(this, task.Result);

        }

        public void Write(CommandReceivedEventArgs e)
        {
            Task task = new Task(() =>
            {
                stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream);
                string toSend = JsonConvert.SerializeObject(e);
                writer.WriteLine(toSend);
                writer.Flush();

            });
            task.Start();
        }
    }
}
